<%

String adostr = "mysql,org.gjt.mm.mysql.Driver,jdbc:mysql://localhost/db1130?user=root&password=passwd1234";

util.DBConnection conn2 = new util.DBConnection(adostr); // 資料庫連線
util.RecordSet rs2 = new util.RecordSet();				 // 儲存結果的變數

String QNO = request.getParameter("QNO");

String sql = "select * from person where pno='"+ QNO + "'";
rs2.Open(conn2,sql);
while (!rs2.EOF){
	System.out.println(rs2.get("pno")+ "," +rs2.get("pname")+ ","+rs2.get("tel"));
	rs2.next();
}
System.out.println("-------OK");
conn2.close();

%>