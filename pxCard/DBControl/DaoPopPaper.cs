using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace pxCard.DBControl
{
    public class DaoPopPaper
    {
        private DataTable _table = new DataTable();

        public string Kind
        {
            get
            {
                return _table.Rows[0]["KIND"].ToString().Trim();
            }
        }
        public bool Direction
        {
            get
            {
                return Convert.ToBoolean(_table.Rows[0]["DIRECTION"]);
            }
        }
        public int Width
        {
            get
            {
                return Convert.ToInt32(_table.Rows[0]["width"]);
            }
        }
        public int Height
        {
            get
            {
                return Convert.ToInt32(_table.Rows[0]["height"]);
            }
        }
        public bool RowFirst
        {
            get
            {
                return (bool)_table.Rows[0]["ROW_FIRST"];
            }
        }
        public int RowSize
        {
            get
            {
                return (int)_table.Rows[0]["ROW"];
            }
        }
        public int ColumnSize
        {
            get
            {
                return (int)_table.Rows[0]["COL"];
            }
        }
        public string Memo
        {
            get
            {
                return _table.Rows[0]["MEMO"].ToString().Trim();
            }
        }
        public string PrinterName
        {
            get
            {
                return _table.Rows[0]["NAME"].ToString().Trim();
            }
        }

        public DaoPopPaper(string conn, string id)
        {
            _table = Get_Paper(conn, id);
            if (_table.Rows.Count == 0)
                throw new Exception("沒有此Paper ID設定資料。");
            if (_table.Rows.Count > 1)
                throw new Exception("此Paper ID有多筆資料。");
        }

        private DataTable Get_Paper(string conn, string id)
        {
            DataTable table = new DataTable();

            using (IDbConnection cn = new SQLiteConnection(conn))
            {
                var insert_sites = cn.ExecuteReader(
$@"
SELECT paper_id
       ,paper_name
       ,kind
       ,direction
       ,width
       ,height
       ,rows
       ,cols
       ,memo
       ,crt_date
   FROM card_paper
  WHERE 1 = 1
    AND paper_id = '{id}';");
                table.Load(insert_sites);
            }

            return table;
        }

    }

}
