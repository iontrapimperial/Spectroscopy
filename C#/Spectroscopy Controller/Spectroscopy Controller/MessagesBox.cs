using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Spectroscopy_Controller
{
    public partial class CoreForm : Form
    {
        /// <summary>
        /// Updates size of box column so that horizontal scrollbar is not required.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MessagesBox_SizeChanged(object sender, EventArgs e)
        {
            this.MessagesBox.Columns[0].Width = this.MessagesBox.Width-30;
        }

        delegate void CallbackDelegateMessageBox(string text, bool isError);

        /// <summary>
        /// Thread safe method to write to messages box. By default messages aren't errors.
        /// </summary>
        /// <param name="text">Message to output.</param>
        /// <param name="isError">If true, background colour of message is set to red and text is set to bold.</param>
        private void WriteMessage(string text, bool isError = false)
        {
            if (this.MessagesBox.InvokeRequired)
            {
                CallbackDelegateMessageBox d = new CallbackDelegateMessageBox(WriteMessage);
                this.Invoke(d, new object[] { text, isError });
            }
            else
            {
                ListViewItem L = new ListViewItem(text);
                
                if (isError)
                {
                    L.BackColor = Color.OrangeRed;
                    L.Font = new Font(L.Font, FontStyle.Bold);
                }
                MessagesBox.Items.Insert(0, L);
            }
        }
        
        /// <summary>
        /// Clears messages in Message box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MessagesClear_Click(object sender, EventArgs e)
        {
            MessagesBox.Items.Clear();
        }
    }
}
