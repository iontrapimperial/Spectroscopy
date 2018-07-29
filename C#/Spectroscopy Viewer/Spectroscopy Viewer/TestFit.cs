using MPFitLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
/* 
    * MINPACK-1 Least Squares Fitting Library
    *
    * Original public domain version by B. Garbow, K. Hillstrom, J. More'
    *   (Argonne National Laboratory, MINPACK project, March 1980)
    * 
    * Translation to C Language by S. Moshier (moshier.net)
    * Translation to C# Language by D. Cuccia (http://davidcuccia.wordpress.com)
    * 
    * Enhancements and packaging by C. Markwardt
    *   (comparable to IDL fitting routine MPFIT
    *    see http://cow.physics.wisc.edu/~craigm/idl/idl.html)
    */

/* Test routines for MPFit library
    $Id: TestMPFit.cs,v 1.1 2010/05/04 dcuccia Exp $
*/
namespace Spectroscopy_Viewer
{
    public class TestFit
    {
        /* Main function which drives the whole thing */
        public static void Main3()
        {
            double[] x = {-1.7237128E+00,1.8712276E+00,-9.6608055E-01,
        -2.8394297E-01,1.3416969E+00,1.3757038E+00,
        -1.3703436E+00,4.2581975E-02,-1.4970151E-01,
        8.2065094E-01};
            double[] y = {-4.4494256E-02,8.7324673E-01,7.4443483E-01,
        4.7631559E+00,1.7187297E-01,1.1639182E-01,
        1.5646480E+00,5.2322268E+00,4.2543168E+00,
        6.2792623E-01};

            //TestGaussFit(x,y);
            //Main2();
        }
        public static double factEval(double val)
        {
            //Console.Write("Value:" + val);
            int myval = Convert.ToInt32(val);
            double result = 1.0;
            while (myval > 1.0)
            {
                //Console.Write("IN while loop");
                result = result * myval;
                myval -= 1;
            }
            return result;
        }

        public static double[] movingAverage(double[] vals)
        {
            double[] retVal = new double[vals.Length];
            retVal[0] = vals[0];
            retVal[1] = vals[1];
            for (int i = 2; i < vals.Length; i++)
            {
                retVal[i] = (vals[i] + vals[i - 1]+vals[i-2]) * 0.33333;
            }
            return retVal;
        }
        public static double[] movingAverage2(double[] vals)
        {
            double[] retVal = new double[vals.Length];
            retVal[vals.Length-1] = vals[vals.Length-1];
            //retVal[1] = vals[1];
            for (int i =0; i < vals.Length-2; i++)
            {
                retVal[i] = (vals[i] + vals[i + 1]) * 0.5;
            }
            return retVal;
        }

        /* Test harness routine, which contains test gaussian-peak data */
        public static double[] TestPoissFit(double[] xinc, double[] yinc)
        {
            
            //First I need to delete the 0's at the end of the yinc
            double totsum = 0.0;
            int i0 = 0;
            while (totsum <3.0) {
                i0 += 1;
                totsum += yinc[yinc.Length - 1];
                yinc = yinc.Take(yinc.Count() - 1).ToArray();
                xinc = xinc.Take(xinc.Count() - 1).ToArray();

                //yinc.RemoveAt(yinc.Length - 1);
                //xinc.RemoveAt(xinc.Length - 1);
            } 
            //now normalize all the data.
            double sum = 0;
            for (int k =0; k < xinc.Length; k++)
            {
                sum = sum + yinc[k];
            }
            for (int k = 0; k < yinc.Length; k++)
            {
                yinc[k] = yinc[k] / sum;
            }

            //Now trim up to i.
            //Now to fit.
            //First average the data.
            double[] averageY = movingAverage(yinc);
            //Now find the max
            double maxY = averageY.Max();
            Console.Write("Max value: " + maxY);
            int indexY = averageY.ToList().IndexOf(maxY);
            Console.Write("Max index: " + indexY);
            //Okay assume that this the average. now subtract it
            double lam1 = indexY;
            double[] subtractedVals = new double[averageY.Length];
            for (int k=0; k < subtractedVals.Length;k++) {
                double y1 = Math.Pow(lam1, k)*Math.Exp(-1.0 * lam1)/(factEval(k));
                subtractedVals[k] = yinc[k]-y1;
                Console.Write("K:" + k + " : " + subtractedVals[k]);
            }
            //Now curve this again
            double[] averageSubtracted = movingAverage2(subtractedVals);
            //Now fit this.
            //Now find the max of this
            double maxY2 = averageSubtracted.Max();
            int indexY2 = averageSubtracted.ToList().IndexOf(maxY2);

            //now to get the last value
            double minX = 1000.0;
            double lam2 = indexY2;
            double closeVal = 0.0;

            Console.Write("Finding intersection");
            for (int i = Convert.ToInt32(Math.Ceiling(lam2)); i < Convert.ToInt32(Math.Ceiling(lam1)); i++)
            {
                Console.Write("Evaling: " + i);
                double y1 = Math.Pow(lam1, i) * Math.Exp(-1.0 * lam1) / (factEval(i));
                double y2 = Math.Pow(lam2, i) * Math.Exp(-1.0 * lam2) / (factEval(i));
                Console.Write("Y1:" + y1 + " y2: " + y2);
                if (Math.Abs(y1-y2) < minX)
                {
                    closeVal = i;
                    minX = Math.Abs(y1 - y2);
                }
            }

            double[] retVal = { lam1, lam2, closeVal};

            return retVal;
        }


        /* Test harness routine, which contains test gaussian-peak data */
        public static double[] TestGaussFit(double[] xinc, double[] yinc,double[] p)
        {
            double[] x = xinc;
            double[] y = yinc;

            double[] ey = new double[yinc.Length];
            //double[] p = { 0.0, 1.0, 1.0, 1.0 };       /* Initial conditions */
            double[] pactual = { 0.0, 4.70, 0.0, 0.5 };/* Actual values used to make data*/
            //double[] perror = new double[4];			   /* Returned parameter errors */
            mp_par[] pars = new mp_par[4] /* Parameter constraints */
                                {
                                    new mp_par(),
                                    new mp_par(),
                                    new mp_par(),
                                    new mp_par()
                                };
            int i;
            int status;

            mp_result result = new mp_result(4);
            //result.xerror = perror;

            /* No constraints */

            for (i = 0; i < yinc.Length; i++) ey[i] = 0.02;

            for (i = 0; i < p.Length; i++)
            {
                Console.Write("P" + i + " : " + p[i]);
            }

            CustomUserVariable v = new CustomUserVariable { X = x, Y = y, Ey = ey };

            /* Call fitting function for 10 data points and 4 parameters (no
               parameters fixed) */
            status = MPFit.Solve(ForwardModels.GaussFunc, yinc.Length, 4, p, pars, null, v, ref result);

            Console.Write("*** TestGaussFit status = {0}\n", status);
            PrintResult(p, pactual, result);
            double[] retval = {p[0],p[1],p[2],p[3],result.xerror[0],result.xerror[1],result.xerror[2],result.xerror[3]};

            return retval;
        }

        /* Simple routine to print the fit results */
        private static void PrintResult(double[] x, double[] xact, mp_result result)
        {
            int i;

            if (x == null) return;

            Console.Write("  CHI-SQUARE = {0}    ({1} DOF)\n",
             result.bestnorm, result.nfunc - result.nfree);
            Console.Write("        NPAR = {0}\n", result.npar);
            Console.Write("       NFREE = {0}\n", result.nfree);
            Console.Write("     NPEGGED = {0}\n", result.npegged);
            Console.Write("       NITER = {0}\n", result.niter);
            Console.Write("        NFEV = {0}\n", result.nfev);
            Console.Write("\n");
            if (xact != null)
            {
                for (i = 0; i < result.npar; i++)
                {
                    Console.Write("  P[{0}] = {1} +/- {2}     (ACTUAL {3})\n",
                       i, x[i], result.xerror[i], xact[i]);
                }
            }
            else
            {
                for (i = 0; i < result.npar; i++)
                {
                    Console.Write("  P[{0}] = {1} +/- {2}\n",
                       i, x[i], result.xerror[i]);
                }
            }
        }
    }

}
