using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QL_SinhVien
{
    public static class MyPublics
    {
        public static SqlConnection conMyConnection;
        public static string strMSSV, strLop, strQuyenSD, strHK, strNK;

        public static void ConnectDatabase()
        {
            string strConn = @"Server=DESKTOP-SLT3JBF; Database=QL_SinhVien; Integrated Security = false ; UID=sa; PWD=616944@TtT";
            conMyConnection = new SqlConnection();
            conMyConnection.ConnectionString = strConn;
            try
            {
                conMyConnection.Open();
            }
            catch (Exception)
            {

            }
        }

        public static void OpenData(string strSelect, DataSet dsDatabase, string strTableName, SqlDataAdapter daDataAdapter)
        {
            try
            {
                if (conMyConnection.State == ConnectionState.Closed)
                    conMyConnection.Open();
                daDataAdapter.SelectCommand = new SqlCommand(strSelect, conMyConnection);
                SqlCommandBuilder cmbCommanBuilder = new SqlCommandBuilder(daDataAdapter);
                Console.WriteLine(daDataAdapter.Fill(dsDatabase, strTableName));

                conMyConnection.Close();
            }
            catch (Exception)
            {

            }
        }

        public static void OpenData(string strSelect, DataSet dsDatabase, string strTableName)
        {
            SqlDataAdapter daDataAdapter = new SqlDataAdapter();
            try
            {
                if (conMyConnection.State == ConnectionState.Closed)
                    conMyConnection.Open();
                daDataAdapter.SelectCommand = new SqlCommand(strSelect, conMyConnection);
                daDataAdapter.Fill(dsDatabase, strTableName);
                conMyConnection.Close();
            }
            catch (Exception)
            {

            }
        }

        public static bool TonTaiKhoaChinh(string strGiaTri, string strTenTruong, string strTable)
        {
            bool blnResult = false;
            try
            {
                string sqlSelect = "Select 1 From " + strTable + " Where " + strTenTruong + " ='" + strGiaTri + "' ";
                if (conMyConnection.State == ConnectionState.Closed)
                    conMyConnection.Open();
                SqlCommand cmdCommand = new SqlCommand(sqlSelect, conMyConnection);
                SqlDataReader drReader = cmdCommand.ExecuteReader();
                if (drReader.HasRows)
                    blnResult = true;
                drReader.Close();
                conMyConnection.Close();
            }
            catch (Exception)
            {

            }
            return blnResult;
        }

        public static string MaHoaPassword(string strPassword)
        {
            string pass="alo";
            return pass;
        }

        public static void XacDinhNKHK()
        {
            int thang = DateTime.Today.Month;
            if(thang <=5)
            {
                strHK = "2";
                strHK = (DateTime.Today.Year - 1) + "-" + (DateTime.Today.Year);
            }
            else
                if (thang <= 7)
                {
                    strHK = "3";
                    strHK = (DateTime.Today.Year - 1) + "-" + (DateTime.Today.Year);
                }
            else
            {
                strHK = "1";
                strHK = (DateTime.Today.Year) + "-" + (DateTime.Today.Year+1);
            }
        }


    }
}
