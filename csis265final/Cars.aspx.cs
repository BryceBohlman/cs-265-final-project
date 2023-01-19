using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using csis265final.DataAccessLayer;

namespace csis265final
{
    public partial class Cars : System.Web.UI.Page
    {
        protected static readonly ILog logger =
    LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected CarDao dao;


        protected void Page_Load(object sender, EventArgs e)
        {
            InstantiateDao();
            if (Page.IsPostBack)
            {

            }
            else
            {

            }
            DisplayCars();
        }

        protected void DisplayCars()
        {
            try
            {
                rptData.DataSource = dao.SelectManyObjects(new Car());
                rptData.DataBind();
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
        }

        protected void InstantiateDao()
        {
            try
            {
                dao = new CarDao();
            }
            catch (DALException ex)
            {
                logger.Error(ex.Message);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
        }

        protected void WipeOutControls()
        {
            txtMake.Text = string.Empty;
            txtModel.Text = string.Empty;
            txtColor.Text = string.Empty;
            txtWeight.Text = string.Empty;
            txtMpg.Text = string.Empty;
            hdnId.Value = string.Empty;
        }

        protected void btnAddCar_Click1(object sender, EventArgs e)
        {
            try
            {
                if (hdnId.Value.Trim().Length > 0)
                {
                    //  EDITING an existing car
                    int id = Convert.ToInt32(hdnId.Value);
                    string make = txtMake.Text;
                    string model = txtModel.Text;
                    string color = txtColor.Text;
                    double weight = Convert.ToDouble(txtWeight.Text);
                    int mpg = Convert.ToInt32(txtMpg.Text);
                    Car obj = new Car(id, make, model, color, weight, mpg);
                    dao.UpdateOneObject(obj);
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "Car updated successfully";
                    logger.Debug("Car updated successfully: " + obj.ToString());
                }
                else
                {
                    //  ADDING a new car
                    string make = txtMake.Text;
                    string model = txtModel.Text;
                    string color = txtColor.Text;
                    double weight = Convert.ToDouble(txtWeight.Text);
                    int mpg = Convert.ToInt32(txtMpg.Text);
                    Car obj = new Car(-1, make, model, color, weight, mpg);
                    dao.InsertOneObject(obj);
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "Car added successfully";
                    logger.Debug("Car added successfully: " + obj.ToString());
                }

                WipeOutControls();
                btnAddCar.Text = "Add Car";
                DisplayCars();
            }
            catch (DALException ex)
            {
                logger.Error(ex.Message);
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Failed to add or edit car";
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Failed to add or edit car";
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                Button btnEdit = (Button)sender;
                RepeaterItem item = (RepeaterItem)btnEdit.NamingContainer;

                Label lblId = (Label)item.FindControl("lblId");
                Label lblMake = (Label)item.FindControl("lblMake");
                Label lblModel = (Label)item.FindControl("lblModel");
                Label lblColor = (Label)item.FindControl("lblColor");
                Label lblWeight = (Label)item.FindControl("lblWeight");
                Label lblMpg = (Label)item.FindControl("lblMpg");

                txtMake.Text = lblMake.Text;
                txtModel.Text = lblModel.Text;
                txtColor.Text = lblColor.Text;
                txtWeight.Text = lblWeight.Text;
                txtMpg.Text = lblMpg.Text;

                hdnId.Value = lblId.Text;

                btnAddCar.Text = "Edit Car";
            }
            catch (DALException ex)
            {
                logger.Error(ex.Message);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Button btnEdit = (Button)sender;
                RepeaterItem item = (RepeaterItem)btnEdit.NamingContainer;

                Label lblId = (Label)item.FindControl("lblId");
                Car obj = new Car(Convert.ToInt32(lblId.Text), "", "", "", -1, -2);
                dao.DeleteOneObject(obj);
                DisplayCars();
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Car deleted successfully";
                logger.Debug("Car deleted successfully)");
            }
            catch (DALException ex)
            {
                logger.Error(ex.Message);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
        }
    }
}