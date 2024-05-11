using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace pxCard.DBControl
{
    class DaoPopFormat
    {
        private DataTable _list = new DataTable();
        private DataTable _detail = new DataTable();

        public string Format_Name
        {
            get { return _list.Rows[0]["format_name"].ToString().Trim(); }
        }

        public float Format_Width
        {
            get { return Convert.ToSingle(_list.Rows[0]["format_width"]); }
        }

        public float Format_Height
        {
            get { return Convert.ToSingle(_list.Rows[0]["format_height"]); }
        }

        public DataTable Format_Detail
        {
            get { return _detail; }
        }

        public DaoPopFormat(string conn, string id)
        {
            _list = Get_Format_List(conn, id);
            if (_list.Rows.Count == 0)
                throw new Exception("沒有此Format ID設定資料。");
            if (_list.Rows.Count > 1)
                throw new Exception("此Format ID有多筆資料。");

            _detail = Get_Format_Detail(conn, id);
        }

        private DataTable Get_Format_List(string conn, string id)
        {
            DataTable table = new DataTable();

            using (IDbConnection cn = new SQLiteConnection(conn))
            {
                var insert_sites = cn.ExecuteReader(
$@"
SELECT 
    format_id
    ,format_name
    ,format_width
    ,format_height
    ,memo
FROM format_list
WHERE 1 = 1
AND format_id = '{id}';");
                table.Load(insert_sites);
            }

            return table;
        }

        private DataTable Get_Format_Detail(string conn, string id)
        {
            DataTable table = new DataTable();

            using (IDbConnection cn = new SQLiteConnection(conn))
            {
                var insert_sites = cn.ExecuteReader(
$@"
select 
    format_id
    ,format_desc
    ,format_seq
    ,print_type
    ,font_name
    ,font_size
    ,font_style
    ,font_color
    ,x_site
    ,y_site
    ,width
    ,height
    ,vertical_align
    ,horizontal_align
    ,matrix
    ,x_zoom
    ,y_zoom
    ,direction_vertical
    ,crt_date
from format_detail
where 1 = 1
and format_id = '{id}';");
                table.Load(insert_sites);
            }

            return table;
        }






    }

}


