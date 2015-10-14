using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;
using BLL;
using DAL;

namespace WebApp
{
    public partial class AddStudents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int moduleID = Convert.ToInt32(Request.QueryString["module"]);

            //get module name
            ModuleHandler moduleHandler = new ModuleHandler();
            Module module = new Module();
            module = moduleHandler.GetModuleDetails(Convert.ToInt32(moduleID));

            litHeader.Text = "<div class='alert alert-info'>" + module.ModuleCode + "</div>";
        }

        protected void btnAddStudents_Click(object sender, EventArgs e)
        {
            string filePath = @"\temp\";

            //check if file is selected
            if (fileUploadControl.HasFile)
            {
                try
                {
                    //only accept .csv files
                    if (fileUploadControl.PostedFile.ContentType == "application/vnd.ms-excel")//for .csv use text/csv
                    {
                        //check file is within maximum size limit
                        if (fileUploadControl.PostedFile.ContentLength < 3072000)
                        {
                            //get file name from the upload control
                            string filename = Path.GetFileName(fileUploadControl.FileName);

                            //get the extension name of the file
                            string extension = filename.Substring(filename.LastIndexOf("."));
                            //remove the extension from the file name
                            filename = filename.Substring(0, filename.LastIndexOf("."));
                            //combine path, file name and extension
                            filePath += filename + extension;

                            //all checks successfull, save file
                            fileUploadControl.SaveAs(Server.MapPath(@"~" + filePath));

                            //now use file contents from local temp folder
                            Student student = new Student();
                            student.ModuleID = Convert.ToInt32(Request.QueryString["module"]);
                            StudentHandler addStudent = new StudentHandler();

                            lblProgress.Text = "<br/>";

                            int moduleID = Convert.ToInt32(Request.QueryString["module"]);
/////////////////////
                            var reader = new StreamReader(File.OpenRead(@"C:\Users\micks\Documents\BitBucket\UAttendWeb\WebApp" + filePath));

                            while (!reader.EndOfStream)
                            {
                                var line = reader.ReadLine();
                                var values = line.Split(',');

                                student.StudentNumber = values[0];
                                student.FirstName = values[1];
                                student.Surname = values[2];
                                student.ModuleID = moduleID;

                                addStudent.AddNewStudent(student);
                            }
                            reader.Close();
                            Response.Redirect("Modules.aspx");
                        }
                        else
                        {
                            lblProgress.Text = "The file has to be less than 3 megabytes!"; 
                        }
                    }
                    else
                    {
                        lblProgress.Text = "Only .csv files are accepted!";
                    }
                }
                catch (Exception ex)
                {
                    lblProgress.Text = "The file failed to upload <br/>" + ex;
                }
            }
            else
            {
                lblProgress.Text = "Select a file to add students";
            }
        }

        protected void btnModules_Click(object sender, EventArgs e)
        {
            Response.Redirect("Modules.aspx");
        }
    }
}