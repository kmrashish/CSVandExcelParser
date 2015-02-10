using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Collections;

namespace ReadFromExcel
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new myForm());
        }
    }
    public class myForm : Form
    {
        public string DestinationConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Ashu\Documents\SecMasterDB.mdf;Integrated Security=True;Connect Timeout=30;";
        public string SourceConnectionString = @"provider=Microsoft.ACE.OLEDB.12.0;Data Source='C:\Users\Ashu\Documents\Visual Studio 2012\Projects\SecMasterVersionTwo\SecMasterAlphaTwo\New Data\Data for securities.xlsx';Extended Properties='Excel 12.0;IMEX=1'";
        //string DestinationConnectionString = @"Data Source=192.168.0.63\DEV05H;Initial Catalog=MCA2015;User ID=mca2015;Password=ivp@123;";
        //string SourceConnectionString=@"provider=Microsoft.ACE.OLEDB.12.0;Data Source='C:\Users\ashikumar\Downloads\Data for securities.xlsx';Extended Properties='Excel 12.0;IMEX=1'";
           
        public myForm()
            : base()
        {
            //this count will keep track of the number of securities stored in the data

            Hashtable equityHashTable = new Hashtable();
            
            equityHashTable.Add("Security Name", "security_name");
            equityHashTable.Add("Security Description", "security_description");
            equityHashTable.Add("Has Position", "has_position");
            equityHashTable.Add("Is Active Security", "is_active");
            equityHashTable.Add("Lot Size", "round_lot_size");
            equityHashTable.Add("BBG Unique Name", "bloomberg_unique_name");
            equityHashTable.Add("CUSIP", "cusip");
            equityHashTable.Add("ISIN", "isin");
            equityHashTable.Add("SEDOL", "sedol");
            equityHashTable.Add("Bloomberg Ticker", "bloomberg_ticker");
            equityHashTable.Add("Bloomberg Unique ID", "bloomberg_unique_id");
            equityHashTable.Add("BBG Global ID", "bloomberg_global_id");
            equityHashTable.Add("Ticker and Exchange", "bloomberg_ticker_and_exchange");
            equityHashTable.Add("Is ADR Flag", "is_adr");
            equityHashTable.Add("ADR Underlying Ticker", "adr_underlying_ticker");
            equityHashTable.Add("ADR Underlying Currency", "adr_underlying_currency");
            equityHashTable.Add("Shares Per ADR", "shares_per_adr");
            equityHashTable.Add("IPO Date", "ipo_date");
            equityHashTable.Add("Pricing Currency", "price_currency");
            equityHashTable.Add("Settle Days", "settle_days");
            equityHashTable.Add("Total Shares Outstanding", "shares_outstanding");
            equityHashTable.Add("Voting Rights Per Share", "voting_rights_per_share");
            equityHashTable.Add("Average Volume - 20D", "twenty_day_average_volume");
            equityHashTable.Add("Beta", "beta");
            equityHashTable.Add("Short Interest", "short_interest");
            equityHashTable.Add("Return - YTD", "ytd_return");
            equityHashTable.Add("Volatility - 90D", "ninty_day_price_volatility");
            equityHashTable.Add("PF Asset Class", "form_pf_asset_class");
            equityHashTable.Add("PF Country", "form_pf_country");
            equityHashTable.Add("PF Credit Rating", "form_pf_credit_rating");
            equityHashTable.Add("PF Currency", "form_pf_currency");
            equityHashTable.Add("PF Instrument", "form_pf_instrument");
            equityHashTable.Add("PF Liquidity Profile", "form_pf_liquid_profile");
            equityHashTable.Add("PF Maturity", "form_pf_maturity");
            equityHashTable.Add("PF NAICS Code", "form_pf_naics_code");
            equityHashTable.Add("PF Region", "form_pf_region");
            equityHashTable.Add("PF Sector", "form_pf_sector");
            equityHashTable.Add("PF Sub Asset Class", "form_pf_sub_asset_class");
            equityHashTable.Add("Country of Issuance", "issue_country");
            equityHashTable.Add("Exchange", "exchange");
            equityHashTable.Add("Issuer", "issuer");
            equityHashTable.Add("Issue Currency", "issue_currency");
            equityHashTable.Add("Trading Currency", "trading_currency");
            equityHashTable.Add("BBG Industry Sub Group", "bloomberg_industry_sub_group");
            equityHashTable.Add("Bloomberg Industry Group", "bloomberg_industry_group");
            equityHashTable.Add("Bloomberg Sector", "bloomberg_industry_sector");
            equityHashTable.Add("Country of Incorporation", "country_of_incorporation");
            equityHashTable.Add("Risk Currency", "risk_currency");
            equityHashTable.Add("Open Price", "open_price");
            equityHashTable.Add("Close Price", "close_price");
            equityHashTable.Add("Volume", "volume");
            equityHashTable.Add("Last Price", "last_price");
            equityHashTable.Add("Ask Price", "ask_price");
            equityHashTable.Add("Bid Price", "bid_price");
            equityHashTable.Add("PE Ratio", "pe_ratio");
            equityHashTable.Add("Dividend Declared Date", "declared_date");
            equityHashTable.Add("Dividend Ex Date", "ex_date");
            equityHashTable.Add("Dividend Record Date ", "record_date");
            equityHashTable.Add("Dividend Pay Date", "pay_date");
            equityHashTable.Add("Dividend Amount", "amount");
            equityHashTable.Add("Frequency", "frequency");
            equityHashTable.Add("Dividend Type", "dividend_type");
            equityHashTable.Add("Security Type", "1");

            
            //Hashtable EquityReverseHashTable = new Hashtable();            
            //foreach (DictionaryEntry entry in equityHashTable)
            //    EquityReverseHashTable.Add(entry.Value, entry.Key);

          
            Hashtable bondHashTable = new Hashtable();
            bondHashTable.Add("Security Description", "security_description");
            bondHashTable.Add("Security Name", "security_name");
            bondHashTable.Add("Asset Type", "asset_type");
            bondHashTable.Add("Investment Type", "investment_type");
            bondHashTable.Add("Trading Factor", "trading_factor");
            bondHashTable.Add("Pricing Factor", "pricing_factor");
            bondHashTable.Add("ISIN", "isin");
            bondHashTable.Add("BBG Ticker", "bloomberg_ticker");
            bondHashTable.Add("BBG Unique ID", "bloomberg_unique_id");
            bondHashTable.Add("CUSIP", "cusip");
            bondHashTable.Add("SEDOL", "sedol");
            bondHashTable.Add("First Coupon Date", "first_coupon_date");
            bondHashTable.Add("Cap", "coupon_cap");
            bondHashTable.Add("Floor", "coupon_floor");
            bondHashTable.Add("Coupon Frequency", "coupon_frequency");
            bondHashTable.Add("Coupon", "coupon_rate");
            bondHashTable.Add("Coupon Type", "coupon_type");
            bondHashTable.Add("Spread", "float_spread");
            bondHashTable.Add("Callable Flag", "is_callable");
            bondHashTable.Add("Fix to Float Flag", "is_fix_to_float");
            bondHashTable.Add("Putable Flag", "is_putable");
            bondHashTable.Add("Issue Date", "issue_date");
            bondHashTable.Add("Last Reset Date", "last_reset_date");
            bondHashTable.Add("Maturity", "maturity_date");
            bondHashTable.Add("Call Notification Max Days", "maximum_call_notice_days");
            bondHashTable.Add("Put Notification Max Days", "maximum_put_notifice_days");
            bondHashTable.Add("Penultimate Coupon Date", "penultimate_coupon_date");
            bondHashTable.Add("Reset Frequency", "reset_frequency");
            bondHashTable.Add("Has Position", "has_position");
            bondHashTable.Add("Macaulay Duration", "duration");
            bondHashTable.Add("30D Volatility", "volatility_thirtyD");
            bondHashTable.Add("90D Volatility", "volatility_nintyD");
            bondHashTable.Add("Convexity", "convexity");
            bondHashTable.Add("30D Average Volume", "average_volume_thirtyD");
            bondHashTable.Add("PF Asset Class", "form_pf_asset_class");
            bondHashTable.Add("PF Country", "form_pf_country");
            bondHashTable.Add("PF Credit Rating", "form_pf_credit_rating");
            bondHashTable.Add("PF Currency", "form_pf_currency");
            bondHashTable.Add("PF Instrument", "form_pf_instrument");
            bondHashTable.Add("PF Liquidity Profile", "form_pf_liquidity_profile");
            bondHashTable.Add("PF Maturity", "form_pf_maturity");
            bondHashTable.Add("PF NAICS Code", "form_pf_naics_code");
            bondHashTable.Add("PF Region", "form_pf_region");
            bondHashTable.Add("PF Sector", "form_pf_sector");
            bondHashTable.Add("PF Sub Asset Class", "form_pf_sub_asset_class");
            bondHashTable.Add("Bloomberg Industry Group", "bloomberg_industry_group");
            bondHashTable.Add("Bloomberg Industry Sub Group", "bloomberg_industry_sub_group");
            bondHashTable.Add("Bloomberg Industry Sector", "bloomberg_industry_sector");
            bondHashTable.Add("Country of Issuance", "country_of_incorporation");
            bondHashTable.Add("Issue Currency", "issue_currency");
            bondHashTable.Add("Issuer", "issuer");
            bondHashTable.Add("Risk Currency", "risk_currency");
            bondHashTable.Add("Put Date", "put_date");
            bondHashTable.Add("Put Price", "put_price");
            bondHashTable.Add("Ask Price", "ask_price");
            bondHashTable.Add("High Price", "high_price");
            bondHashTable.Add("Low Price", "low_price");
            bondHashTable.Add("Open Price", "open_price");
            bondHashTable.Add("Volume", "volume");
            bondHashTable.Add("Bid Price", "bid_price");
            bondHashTable.Add("Last Price", "last_price");
            bondHashTable.Add("Call Date", "call_date");
            bondHashTable.Add("Call Price", "call_price");
            bondHashTable.Add("Security Type", "2");

            //Hashtable BondReverseHashTable = new Hashtable();
            //foreach (DictionaryEntry entry in equityHashTable)
            //    BondReverseHashTable.Add(entry.Value, entry.Key);
            int noOfSecuritiesNow = CountSecurities();
                
            
       
            //establish the OLEDB connection and fetch the contents from the equity file into a dataset (ds here)
            OleDbConnection con;
            DataSet ds;
            OleDbDataAdapter adapter;
            //con = new OleDbConnection(@"provider=Microsoft.ACE.OLEDB.12.0;Data Source='C:\Users\ashikumar\Downloads\Equity File.xls';Extended Properties='Excel 12.0;IMEX=1'");
            con = new OleDbConnection(SourceConnectionString);
            adapter = new OleDbDataAdapter("select * from [Equities$]", con);
            adapter.TableMappings.Add("Table", "TestTable");
            ds = new DataSet();
            adapter.Fill(ds);
            con.Close();

            DataTable dsn = new DataTable();
            dsn = ds.Tables[0].Rows.Cast<DataRow>().Where(row => !row.ItemArray.All(field => field is System.DBNull || string.Compare((field as string).Trim(), string.Empty) == 0)).CopyToDataTable();

            //string[] fields = { "CUSIP", "ISIN", "SEDOL", "Bloomberg Ticker", "Bloomberg Unique ID", "BBG Global ID", "Ticker and Exchange" };
            //DataTable security_identifier_datatable = dsn.DefaultView.ToTable(false, fields);
            //DataColumn sectype = new DataColumn("Security Type");
            //sectype.DefaultValue = 1;
            //security_identifier_datatable.Columns.Add(sectype);
            //sectype.SetOrdinal(0);
            //WriteToTable(security_identifier_datatable, "core.ivp_securityMaster_core_securityidentifier", fields, equityHashTable);


            //string[] refFields = { "Country of Issuance", "Exchange", "Issuer", "Issue Currency", "Trading Currency", "BBG Industry Sub Group", "Bloomberg Industry Group", "Bloomberg Sector", "Country of Incorporation", "Risk Currency" };
            //DataTable security_referencedata_datatable = dsn.DefaultView.ToTable(false, refFields);
            //DataColumn sectypeInReference = new DataColumn("Security Type");
            //sectypeInReference.DefaultValue = 1;
            //security_referencedata_datatable.Columns.Add(sectypeInReference);
            //sectypeInReference.SetOrdinal(0);
            //WriteToTable(security_referencedata_datatable, "core.ivp_securityMaster_core_referencedata", refFields, equityHashTable);

            DataTable Equity_summary_datatable = new DataTable();
            DataColumn fk_sec_id = Equity_summary_datatable.Columns.Add("Foreign Key", typeof(Int32));
            fk_sec_id.AutoIncrement = true;
            fk_sec_id.AutoIncrementSeed = noOfSecuritiesNow;
            fk_sec_id.AutoIncrementStep = 1;
            string[] EquitySummaryFields = { "Security Name", "Security Description", "Has Position", "Is Active Security", "Lot Size", "BBG Unique Name" };
            Equity_summary_datatable = dsn.DefaultView.ToTable(false, EquitySummaryFields);
            WriteToTable(Equity_summary_datatable, "eq.ivp_securityMaster_securitysummary", EquitySummaryFields, equityHashTable);

            //string[] EquityDetailsFields = { "Is ADR Flag", "ADR Underlying Ticker", "ADR Underlying Currency", "Shares Per ADR", "IPO Date", "Pricing Currency", "Settle Days", "Total Shares Outstanding", "Voting Rights Per Share", "PF Asset Class", "PF Country", "PF Credit Rating", "PF Currency", "PF Instrument", "PF Liquidity Profile", "PF Maturity", "PF NAICS Code", "PF Region", "PF Sector", "PF Sub Asset Class" };
            //DataTable Equity_details_datatable = dsn.DefaultView.ToTable(false, EquityDetailsFields);
            //WriteToTable(Equity_details_datatable, "eq.ivp_securityMaster_securitydetails", EquityDetailsFields, equityHashTable);

            //string[] EquityRiskFields = { "Average Volume - 20D", "Beta", "Short Interest", "Return - YTD", "Volatility - 90D" };
            //DataTable Equity_risk_datatable = dsn.DefaultView.ToTable(false, EquityRiskFields);
            //WriteToTable(Equity_risk_datatable, "eq.ivp_securityMaster_risk", EquityRiskFields, equityHashTable);

            //string[] EquityPricingDetailsFields = { "Open Price", "Close Price", "Volume", "Last Price", "Ask Price", "Bid Price","PE Ratio"};
            //DataTable Equity_pricing_details_datatable = dsn.DefaultView.ToTable(false, EquityPricingDetailsFields);
            //WriteToTable(Equity_pricing_details_datatable, "eq.ivp_securityMaster_pricingdetails", EquityPricingDetailsFields, equityHashTable);

            string[] EquityDividendHistoryFields = { "Dividend Declared Date", "Dividend Ex Date", "Dividend Record Date ", "Dividend Pay Date", "Dividend Amount", "Frequency", "Dividend Type" };
            DataTable Equity_dividend_history_datatable = dsn.DefaultView.ToTable(false, EquityDividendHistoryFields);
            WriteToTable(Equity_dividend_history_datatable, "eq.ivp_securityMaster_dividendhistory", EquityDividendHistoryFields, equityHashTable);

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////
            //parsing the bond file and sending it to the database tables//

            //OleDbConnection conB;
            //DataSet dsB;
            //OleDbDataAdapter adapterB;
            ////con = new OleDbConnection(@"provider=Microsoft.ACE.OLEDB.12.0;Data Source='C:\Users\ashikumar\Downloads\Equity File.xls';Extended Properties='Excel 12.0;IMEX=1'");
            //conB = new OleDbConnection(SourceConnectionString);
            //adapterB = new OleDbDataAdapter("select * from [Bonds$]", conB);
            //adapterB.TableMappings.Add("TableB", "TestTableB");
            //dsB = new DataSet();
            //adapterB.Fill(dsB);
            //conB.Close();

            //string[] fieldsB = { "CUSIP", "ISIN", "SEDOL", "BBG Ticker", "BBG Unique ID"};
            //DataTable security_identifier_datatableB = dsB.Tables[0].DefaultView.ToTable(false, fieldsB);
            //security_identifier_datatableB = security_identifier_datatableB.Rows.Cast<DataRow>().Where(row => !row.ItemArray.All(field => field is System.DBNull || string.Compare((field as string).Trim(), string.Empty) == 0)).CopyToDataTable();
            //DataColumn sectypeB = new DataColumn("Security Type");
            //sectypeB.DefaultValue = 2;
            //security_identifier_datatableB.Columns.Add(sectypeB);
            //sectypeB.SetOrdinal(0);
            //WriteToTable(security_identifier_datatableB, "core.ivp_securityMaster_core_securityidentifier", fieldsB, bondHashTable);

            //string[] refFieldsB = { "Bloomberg Industry Group", "Bloomberg Industry Sub Group", "Bloomberg Industry Sector", "Country of Issuance", "Issue Currency", "Issuer", "Risk Currency"};
            //DataTable security_referencedata_datatableB = dsB.Tables[0].DefaultView.ToTable(false, refFieldsB);
            //security_referencedata_datatableB = security_referencedata_datatableB.Rows.Cast<DataRow>().Where(row => !row.ItemArray.All(field => field is System.DBNull || string.Compare((field as string).Trim(), string.Empty) == 0)).CopyToDataTable();
            //DataColumn sectypeInReferenceB = new DataColumn("Security Type");
            //sectypeInReferenceB.DefaultValue = 2;
            //security_referencedata_datatableB.Columns.Add(sectypeInReferenceB);
            //sectypeInReferenceB.SetOrdinal(0);
            //WriteToTable(security_referencedata_datatableB, "core.ivp_securityMaster_core_referencedata", refFieldsB, bondHashTable);

            //string[] BondSummaryFields = { "Security Name", "Security Description", "Asset Type", "Investment Type", "Trading Factor", "Pricing Factor" };
            //DataTable Bond_summary_datatable = dsB.Tables[0].DefaultView.ToTable(false, BondSummaryFields);
            //Bond_summary_datatable = Bond_summary_datatable.Rows.Cast<DataRow>().Where(row => !row.ItemArray.All(field => field is System.DBNull || string.Compare((field as string).Trim(), string.Empty) == 0)).CopyToDataTable();
            //DataColumn sectypeInReferenceB = new DataColumn("Is Active");
            //sectypeInReferenceB.DefaultValue = "TRUE";
            //Bond_summary_datatable.Columns.Add(sectypeInReferenceB);
            //sectypeInReferenceB.SetOrdinal(0);
            //WriteToTable(Bond_summary_datatable, "cb.ivp_securityMaster_securitysummary", BondSummaryFields, bondHashTable);






               
        }

        
        private void WriteToTable(DataTable source_datatable, string destination_table_name, string[] fields, Hashtable SecurityHashTable)
        {
            using (SqlConnection conn = new SqlConnection(DestinationConnectionString))
            {
                conn.Open();
                using (SqlBulkCopy sbc = new SqlBulkCopy(conn))
                {
                    sbc.DestinationTableName = destination_table_name;
                    try
                    {
                        if (destination_table_name == "core.ivp_securityMaster_core_securityidentifier" || destination_table_name == "core.ivp_securityMaster_core_referencedata") sbc.ColumnMappings.Add("Security Type", "sectype");
                        if (destination_table_name == "cb.ivp_securityMaster_securitysummary") sbc.ColumnMappings.Add("Is Active","is_active");
                        foreach(string f in fields)
                        sbc.ColumnMappings.Add(f.ToString(), SecurityHashTable[f.ToString()].ToString());                                                
                        sbc.WriteToServer(source_datatable);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }

        protected int CountSecurities()
        {
            //string connectionString = @"Data Source=192.168.0.63\DEV05H;Initial Catalog=MCA2015;User ID=mca2015;Password=ivp@123;";
            string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Ashu\Documents\SecMasterDB.mdf;Integrated Security=True;Connect Timeout=30;";

            SqlConnection conn = new SqlConnection(connectionString);
            int noOfSecuritiesNow = 0;
            try
            {
                conn.Open();
                string query = "select count(*) from core.ivp_securityMaster_core_securityidentifier";
                //SqlDataReader rdr;
                SqlCommand cmd = new SqlCommand(query, conn);
                noOfSecuritiesNow = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message);  }
            finally { conn.Close(); }
            return noOfSecuritiesNow;           
        }

       

    }
}