using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace ConsoleApplication7
{
    class Parser
    {
        static void Main(string[] args)
        {
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
            equityHashTable.Add("Ticker and Exchange", "bloombert_ticker_and_exchange");
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
            equityHashTable.Add("Dividend Record Date", "record_date");
            equityHashTable.Add("Dividend Pay Date", "pay_date");
            equityHashTable.Add("Dividend Amount", "amount");
            equityHashTable.Add("Frequency", "frequency");
            equityHashTable.Add("Dividend Type", "dividend_type");

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
            bondHashTable.Add("Cap", "bloomberg_global_id");
            bondHashTable.Add("Floor", "bloombert_ticker_and_exchange");
            bondHashTable.Add("Coupon Frequency", "is_adr");
            bondHashTable.Add("Coupon", "adr_underlying_ticker");
            bondHashTable.Add("Coupon Type", "adr_underlying_currency");
            bondHashTable.Add("Spread", "shares_per_adr");
            bondHashTable.Add("Callable Flag", "ipo_date");
            bondHashTable.Add("Fix to Float Flag", "price_currency");
            bondHashTable.Add("Putable Flag", "settle_days");
            bondHashTable.Add("Issue Date", "shares_outstanding");
            bondHashTable.Add("Last Reset Date", "voting_rights_per_share");
            bondHashTable.Add("Maturity", "twenty_day_average_volume");
            bondHashTable.Add("Call Notification Max Days", "beta");
            bondHashTable.Add("Put Notification Max Days", "short_interest");
            bondHashTable.Add("Penultimate Coupon Date", "ytd_return");
            bondHashTable.Add("Reset Frequency", "ninty_day_price_volatility");
            bondHashTable.Add("Has Position", "form_pf_asset_class");
            bondHashTable.Add("Macaulay Duration", "form_pf_country");
            bondHashTable.Add("30D Volatility", "form_pf_credit_rating");
            bondHashTable.Add("90D Volatility", "form_pf_currency");
            bondHashTable.Add("30D Average Volume","form_pf_instrument");
            bondHashTable.Add("PF Asset Class", "form_pf_liquid_profile");
            bondHashTable.Add("PF Country", "form_pf_maturity");
            bondHashTable.Add("PF Credit Rating", "form_pf_naics_code");
            bondHashTable.Add("PF Currency", "form_pf_region");
            bondHashTable.Add("PF Instrument", "form_pf_sector");
            bondHashTable.Add("PF Liquidity Profile", "form_pf_sub_asset_class");
            bondHashTable.Add("PF Maturity", "issue_country");
            bondHashTable.Add("PF NAICS Code", "exchange");
            bondHashTable.Add("PF Region", "issuer");
            bondHashTable.Add("PF Sector", "issue_currency");
            bondHashTable.Add("PF Sub Asset Class", "trading_currency");
            bondHashTable.Add("Bloomberg Industry Group", "bloomberg_industry_sub_group");
            bondHashTable.Add("Bloomberg Industry Sub Group", "bloomberg_industry_group");
            bondHashTable.Add("Bloomberg Industry Sector", "bloomberg_industry_sector");
            bondHashTable.Add("Country of Issuance", "country_of_incorporation");
            bondHashTable.Add("Issue Currency", "risk_currency");
            bondHashTable.Add("Issuer", "open_price");
            bondHashTable.Add("Risk Currency", "risk_currenty");
            bondHashTable.Add("Put Date", "volume");
            bondHashTable.Add("Put Price", "last_price");
            bondHashTable.Add("Ask Price", "ask_price");
            bondHashTable.Add("High Price", "bid_price");
            bondHashTable.Add("Low Price", "pe_ratio");
            bondHashTable.Add("Open Price", "declared_date");
            bondHashTable.Add("Volume", "ex_date");
            bondHashTable.Add("Bid Price", "record_date");
            bondHashTable.Add("Last Price", "pay_date");
            bondHashTable.Add("Call Date", "amount");
            bondHashTable.Add("Call Price", "frequency");

            //Hashtable bondHashTable = new Hashtable();
            //bondHashTable.Add();
            //similarily form the hashtable for the mapping of the bond file field names and the column names in the database tables
            //form the insertion queries for the bond type in the same manner or call the stored procedures as per required

            //string[] allData = System.IO.File.ReadAllLines(@"C:\Users\ashikumar\Downloads\Data for securities.csv");
            string[] allData = System.IO.File.ReadAllLines(@"C:\Users\ashikumar\Downloads\Data for securities.csv");
            string attributeHeadersUnseperated = allData[0];
            string[] attributeHeadersSeperated = attributeHeadersUnseperated.Split('|');

            string queryHeadersPart = string.Empty;

            string[] attributes=new string[100];
            string[] data=new string[100];

            int x = 0;

            foreach (string s in attributeHeadersSeperated)
            {
                Console.Write(s);                                 
                queryHeadersPart += equityHashTable[s] + ","; attributes[x] = s;
                x++;
            }
            queryHeadersPart = queryHeadersPart.Remove(0, 1);
            queryHeadersPart = queryHeadersPart.Substring(0, queryHeadersPart.LastIndexOf(','));
            
            Console.WriteLine("\n");
            Console.WriteLine(queryHeadersPart);
            Console.WriteLine();

            string newString = "";
            int p = 0;
            int i = 0;
            for (i = 1; i < allData.Length; i++)
            {

                string queryValues = string.Empty;
                string dataRowUnseperated = allData[i];
                string[] dataRowSeperated = dataRowUnseperated.Split('|');

                p = 0;
                foreach (string dr in dataRowSeperated)
                {
                    //Console.WriteLine(dr);
                    data[p] = dr; p++;
                }

                newString = "";
                int t = 0;
                for (t = 1; t <= x; t++)
                {
                    if (data[t] != null)
                        newString += "@" + equityHashTable[attributes[t]] + "='" + data[t] + "', ";
                }
                newString = newString.Substring(0, newString.LastIndexOf(','));
                Console.WriteLine(newString);
                Console.WriteLine();
                Console.WriteLine();

                //SqlCommand spcmd = new SqlCommand("exec stored_proc ");
            }            

            Console.WriteLine("\n\n");  
            
            //OleDbConnection con;
            //DataSet ds;
            //OleDbDataAdapter adapter;
            //con = new OleDbConnection(@"provider=Microsoft.Jet.OLEDB.4.0;Data Source='E:\Indus Valley Partners\SecurityMaster\Data for securities.xlsx';Extended Properties=Excel 8.0;");
            //adapter = new OleDbDataAdapter("select * from [Equities$]", con);
            //adapter.TableMappings.Add("Table", "TestTable");
            //ds = new DataSet();
            //adapter.Fill(ds);
            //DataTable dt = ds.Tables[0];
            
            

            //DataRow drxls = ds.Tables[0].Rows[0];
            //Console.WriteLine(ds.Tables[0].Rows[0].ToString());
            


            //con.Close();




            Console.Read();
        }
        
    }
}
