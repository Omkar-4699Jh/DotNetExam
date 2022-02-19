using DotNetExam.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DotNetExam.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DotNetExam;Integrated Security=True";
            con.Open();
            SqlCommand cmdDisplay = new SqlCommand();
            cmdDisplay.Connection = con;
            cmdDisplay.CommandType = System.Data.CommandType.StoredProcedure;
            cmdDisplay.CommandText = "FetchProducts";
            List<Products> prd = new List<Products>();
            try
            {
                SqlDataReader dre = cmdDisplay.ExecuteReader();
                while (dre.Read())
                {
                    prd.Add(new Products
                    {
                        ProductId = (int)dre["ProductId"],
                        ProductName = dre["ProductName"].ToString(),
                        Description = dre["Description"].ToString(),
                        Rate = (int)(decimal)dre["Rate"],
                        CategoryName = dre["CategoryName"].ToString()

                    });
                 }
            }
            catch
            {

            }
            finally
            {
                con.Close();
            }
            return View(prd);
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            Products prd = new Products();
            return View();
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Products prd)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DotNetExam;Integrated Security=True";
            con.Open();
            SqlCommand cmdEdit = new SqlCommand();
            cmdEdit.Connection = con;
            cmdEdit.CommandType = System.Data.CommandType.StoredProcedure;
            cmdEdit.CommandText = "UpdateProducts";
            cmdEdit.Parameters.AddWithValue("@ProductId", id);
            cmdEdit.Parameters.AddWithValue("@ProductName", prd.ProductName);
            cmdEdit.Parameters.AddWithValue("@Description", prd.Description);
            cmdEdit.Parameters.AddWithValue("@Rate", prd.Rate);
            cmdEdit.Parameters.AddWithValue("@CategoryName", prd.CategoryName);
            try
            {
                cmdEdit.ExecuteNonQuery();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            finally
            {
                con.Close();
            }
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Products/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
