---------------------------------------------------
• 完成進度
   - 【OK】2022/01/02 01:40 至第二頁
   - 【OK】2022/01/02 08:30 至第三頁 (圖二、系統架構圖)
   - 【OK】2022/01/03 11:25 至第五頁
   - 【】2022/00/00 00:00 至第頁
   - 【】2022/00/00 00:00 至第頁
   - 【】2022/00/00 00:00 至第頁
---------------------------------------------------
```
廣告傳單寄發管理系統 
Advertising leaflet delivery management system
縮寫：ALDMS
ALDMS Design Document Version (設計文檔版本)
```
---------------------------------------------------
```
• 系統模型與架構 (我負責)
    - 子系統功能與介面
    - 技術解決方案限制
• 系統管理子系統細部設計(SMS) (我負責)
    - 元件設計 (Component Design)
    - 流程分析 (Process Analysis)
    - 資料設計 (Data Design)
    - 界面設計 (Interface Design)
• 購物資料管理子系統細部設計(SIMS) (4080I017李正德)
    - 元件設計 (Component Design)
    - 流程分析 (Process Analysis)
    - 資料設計 (Data Design)
    - 界面設計 (Interface Design)
• 銷售分析寄送子系統細部設計(SADS) (4080I017李正德)
    - 元件設計 (Component Design)
    - 流程分析 (Process Analysis)
    - 資料設計 (Data Design)
    - 界面設計 (Interface Design)
```
---------------------------------------------------

廣告傳單寄發管理系統
---------------------------------
客戶資料系統
(Customer Information System)(CIS)
---------------------------------
購物資料系統
(Shopping Information System)(ADS)
---------------------------------
廣告寄送系統
(Advertising delivery system)(ADS)
---------------------------------
系統架構圖
(System architecture diagram)(SAD)
---------------------------------------------------
客戶姓名 | 性別 | 電話 | 地址 | 偏好商品 
貨品名稱 | 類別ID | 公司 | 代理商 | 聯絡資訊 
------------------------------------------------------ 
Customer Name | Gender | Phone | Address | Preferred Products 
CUST

Product Name | Category ID | Company | Agent | Contact Information 

Authority 權限 (ATY)
Revise 修改 (REV)
Agent 代理商
---------------------------------------------------
問題解析：
 ?? adostr：登入時會使用到的一種 jsp 技術
