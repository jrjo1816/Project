using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BASEC.FORM;

namespace BASEC.FORM
{
    static public class CForm
    {
        public static FormMother frmMother = null;
        public static FormTitle frmTitle = new FormTitle();
        public static FormMenu frmMenu = new FormMenu();
        public static FormMain frmMain = new FormMain();
        public static FormOne frmOne = new FormOne();
        public static FormTwo frmTwo = new FormTwo();

        //Page
        public static List<System.Windows.Forms.Form> listPage = new List<System.Windows.Forms.Form>(); //Page Manager List
        public static System.Windows.Forms.Form frmCurrentPage = null;
        public static FormMain frmPageMain = new FormMain();
        public static FormOne frmPageOne = new FormOne();
        public static FormTwo frmPageTwo = new FormTwo();

        public static void init_Form()
        {
            listPage.Clear();
            Add_Form(frmMother.pnlMotherTop, frmTitle); //Frame Title
            Add_Form(frmMother.pnlMotherBottom, frmMenu); //Frame Title
            //Add_Form(frmMother.pnlMotherMain, frmMain); //Frame Title
            Add_Page(frmMain);
            Add_Page(frmOne);
            Add_Page(frmTwo);

            for (int i = 0; i < listPage.Count; i++)
            {
                Add_AllControls(listPage[i]);
            }
            Add_AllControls(frmMother);
            Add_AllControls(frmTitle);
            Add_AllControls(frmMenu);
            Add_AllControls(frmMain);
            Add_AllControls(frmOne);
            Add_AllControls(frmTwo);
        }
        private static void Add_AllControls(System.Windows.Forms.Form form)
        {
            System.Windows.Forms.Control.ControlCollection ctrl = form.Controls;
            Add_Controls(ctrl);
        }

        private static void Add_Controls(System.Windows.Forms.Control.ControlCollection ctrl)
        {
            foreach (System.Windows.Forms.Control con in ctrl)
            {
                if (con.Controls.Count > 0)
                {
                    Add_Controls(con.Controls);
                }
                //listControl.Add(con);
            }
        }

        public static void Add_Form(System.Windows.Forms.Panel pnl, System.Windows.Forms.Form form)
        {
            form.TopMost = true;
            form.TopLevel = false;
            form.Parent = frmMother;
            pnl.Controls.Add(form);
            form.Show();
        }

        private static void Add_Page(System.Windows.Forms.Form form)
        {
            form.TopMost = true;
            form.TopLevel = false;
            form.Parent = frmMother;
            frmMother.pnlMotherMain.Controls.Add(form);
            listPage.Add(form);
            form.Hide();
        }

        public static void Hide_Application()
        {
            frmMother.ShowInTaskbar = false;
            frmMother.Hide();
        }

        public static void Show_Application()
        {
            System.Windows.Forms.Form Form = frmMother;
            bool bOpened = false;
            foreach (System.Windows.Forms.Form frm in System.Windows.Forms.Application.OpenForms)
            {
                if (frm.Name == Form.Name)
                {
                    bOpened = true;
                }
            }
            if (bOpened)
            {
                Form.Hide();
            }
            Form.ShowInTaskbar = true;
            Form.Show();
        }

        //Show Main Window
        public static void Display_Page(System.Windows.Forms.Form form)
        {
            frmCurrentPage = form;
            string strNameForm = form.Name;
            for (int i = 0; i < listPage.Count; i++)
            {
                if (listPage[i].Name == strNameForm)
                {
                    listPage[i].Show();
                }
                else
                {
                    listPage[i].Hide();
                }
            }
        }

    }
}
