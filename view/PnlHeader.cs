using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace view
{
    class PnlHeader:Panel
    {
        private Button signIn;
        private Button myProfile;
        public PnlHeader()
        {
            signIn = new Button();
            signIn.Width = 90;
            signIn.Height = 30;
            signIn.Location = new System.Drawing.Point(569, 27);
            signIn.Text = "Sign In";
            signIn.BackColor = Color.White;
            this.Controls.Add(signIn);

            myProfile = new Button();
            myProfile.Width = 90;
            myProfile.Height = 30;
            myProfile.Location = new Point(682, 27);
            myProfile.Text = "My profile";
            myProfile.BackColor = Color.White;
            this.Controls.Add(myProfile);

            this.Location = new Point(0, 0);
            this.Width = 831;
            this.Height = 72;
            this.BackColor = Color.Black;
            this.Name = "header";
        }


       
    }
}
