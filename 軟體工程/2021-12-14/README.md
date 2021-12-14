
### ajax_01.jsp
```jsp
<%@page import = "java.util.*, java.io.*, util.*, compweb.*,org.json.simple.JSONObject" %>
<%@page contentType="text/html; charset=utf-8" %>
<%
   request.setCharacterEncoding("UTF-8");
   System.out.println("=>OK");
   JSONObject json = new JSONObject();
   json.put("isExist","False");
   json.put("name","王小明");
   String jString = JSONObject.toJSONString(json);
	out.println(jString);   
%>
```
### index.jsp
```
<%@page import = "java.util.*, java.io.*, util.*, compweb.*" %>
<%@page contentType="text/html; charset=utf-8" %>
<%
   request.setCharacterEncoding("UTF-8");
%>
<!DOCTYPE html>
<html>
<head>
<title></title>
<meta name="viewport" content="width=device-width, initial-scale=1">
</head>
<script type="text/javascript" src='js/jquery-1.9.1.min.js'></script>
<link rel="stylesheet" type="text/css" href="js/basictable.css" />
<script type="text/javascript" src="js/jquery.basictable.min.js"></script>
<link rel="stylesheet" type="text/css" href="index.css" />

<body>
<form method="POST" name="REQFORM" action="index.jsp">
    <input type="hidden" name="restType" value="">
    <input type="hidden" name="UserID" value="">
    <input type="hidden" name="CUST_NO" value="">
</form>

<div class="header">作業</div>
<div class="navbar"> <!-- Navigation Bar -->
  <!--<a href="#">Link</a>-->
  <!--<a href="#">Link</a>-->
  <!--<a href="#">Link</a>-->
  <a href="#" onClick="AllSubmit('EXIT')">返回</a>
</div>

<!-- The flexible grid (content) -->
<div class="row">
  <div class="side">
      <img id="showimg" class="fakeimg" src="images/mea_imgs/000.jpg" width="100%;">
  </div>
  <div class="main lg">
      <div class="main_in">
          <h4 id="InfoUserBasic">基本資料</h4>    
          <div class="blk_lab">姓名:</div><div class="blk_txt"></div>
          <div class="blk_lab">編號:</div><div class="blk_txt"></div>
      </div>
      <div class="main_in">
          <div class="blk_end">位置:<a id="msg_pos2">-</a></div>
          <div class="blk_end">名稱:<a id="msg_pos3">-</a></div>
          <div class="blk_end" id="BoxMsg">&nbsp;</div>
          <div class="blk_end"><a id="msg_pos1">-</a></div>
          <center>
              <input type="button" value="連線" id="but_mstart" class="but_ok" onClick="checkID()" />
              <input type="button" value="中斷" id="but_mstop" class="but_ok" onClick="" />
          </center>
      </div>
      <div class="main_in">
          <h4>詳細資訊</h4>
          <div class="blk_lab" id="InfoMeaName">-</div>
          <div class="blk_end" id="InfoMeaDesc">-</div>
      </div>
      <div class="main_in" id="prg_scrn" style="visibility: hidden;">
          <div class="blk_end" id="BoxTitle">TEST</div>
          <progress id="BoxStatus" value="32" max="100"></progress><center id="BoxText">32%</center>
      </div>
  </div>
</div>
    
<!-- Footer -->
<div class="footer">

</div> <!-- footer -->

<style type="text/css">
    #file {
        width: 250px;
        float: left;
    }
</style>    


<form name="MEAS_ANALYSIS" action="measure_charts.jsp" method="post" target="meas_frame">
    <input type="hidden" name="DEVICE_ID" id="DEVICE_ID" value="" />
    <input type="hidden" name="CUST_NO" id="CUST_NO" value="" />
    <input type="hidden" name="RDID" id="RDID" value="" />
</form>

<!-- Popup Box [量測分析] -------------------------------------------------->
<!-- The Modal -->
<button id="myBtn"></button>
<div id="analysis" class="analysis_modal">
  <!-- Modal content -->
  <div class="analysis_modal-content">
    <div class="analysis_modal-header">
      <span id="analysis_close" onClick="analysis_close()">&times;</span>
      <h4><button value="" onClick="chart_print()">列印</button></h4>
    </div>
    <div class="analysis_modal-body container">
        <iframe name="meas_frame" id="meas_frame" class="iframe-class" src="" width="1000px" height="600px"></iframe>         
    </div>
    <div class="analysis_modal-footer">
      <h3>Modal Footer</h3>
    </div>
  </div>
</div>
<!-- Popup Box [量測分析] -------------------------------------------------->


</body>    
<Script type="text/javascript">
function checkID(){
	$.ajax({		
        url: 'ajax_01.jsp',
        type:"POST",
		dataType: "json",
		data:{action:'CHECK_ID',DEVICE_ID:'A01'},
		contentType: "application/x-www-form-urlencoded; charset=utf-8",
        success: function (data) {
            //alert("OK");
            alert(data.isExist + "," + data.name)
			//if (data.isExist=='true'){
            //    alert("OK");
			//} else {
                /*******************************************/
                //document.getElementById("BoxMsg").innerHTML = "ID不存在!";
                //document.getElementById("but_reset").style.visibility = "visible";
                //valInd = 0;
                /*******************************************/
			//}
        },
        error: function (data, status, errorThrown) {
			alert("Error:"+data+" "+errorThrown);
        }
    });	
}
</script>
```
