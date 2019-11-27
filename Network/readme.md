#
| | OSI Model   |        |Network Devices|
|-| ------------| ------ | ------ | 
|7| Application | 應用層 | proxy / Layer-7 Switch | 
|6| Presentation| 表達層 | |
|5| Session     | 會議層 | |
|4| Transport   | 傳輸層 | Layer-4 / Switch | 
|3| Network     | 網路層 | router / Layer-3 Switch | 
|2| Data Link   | 連結層 | Bridge(1-1) / Switch(1-N) | 
|1| Physcial    | 實體層 | Repeater(1-1) / Hub(1-N) |

|TCP/IP協定  |       |      |
| ----------| ------ |-----|
|Application|→       |Application/Presentation/Session|
|Transport  |→       |Transport|
|InterNet   |→       |Network|
# 網路硬體
```
Layer-1 : repeater(1-1), hub(1-N)
Layer-2 : bridgr, switch
Layer-3 : router,L3-Switch
Layer-4 : L4 switch
Layer-7 : L7 switch, proxy
```
# 1 實體層 Physical Layer
```
● 在局部區域網路上傳送資料框（data frame），它負責管理電腦通訊裝置和網路媒體之間的互通。
  包括了針腳、電壓、線纜規範、集線器、中繼器、網卡、主機介面卡等。
```
# 2 資料連結層 Data Link Layer
```
● 資料連結層（Data Link Layer）負責網路尋址、錯誤偵測和改錯。
  當表頭和表尾被加至資料包時，會形成影格。資料連結串列頭（DLH）是包含了實體位址和錯誤偵測及改錯的方法。
  資料連結串列尾（DLT）是一串指示資料包末端的字串。例如乙太網、無線區域網路（Wi-Fi）和通用分組無線服務（GPRS）等。
  
 ─ 分為兩個子層：邏輯鏈路控制（logical link control，LLC）子層和媒介存取控制（Media access control，MAC）子層。
```
# 3 網路層 Network Layer
```
● 網路層（Network Layer）決定資料的路徑選擇和轉寄，將網路表頭（NH）加至資料包，以形成封包。
  網路表頭包含了網路資料。例如:網際網路協定（IP）等。

 ─ 邏輯定址：將區段(Segment)加上傳輸雙方的IP位址，以產生資料封包(Packet)。

 ─ 路徑選擇：考慮網路的壅塞程度、發送的優先權…等，以規劃封包(Packet)最佳傳輸路徑。
```
# 4 傳輸層 Transport Layer
```
● 傳輸層（Transport Layer）把傳輸表頭（TH）加至資料以形成資料包。
  傳輸表頭包含了所使用的協定等傳送資訊。例如:傳輸控制協定（TCP）等。
  
  傳輸層會將訊息(Data or Message)切割成區段(Segment)並加上編號，以利接收端重組區段(Segment)。
  該層也會進行流量控制與偵錯處理。
  
  ─ 流量控制：網路壅塞時，會停止資料傳送。

  ─ 偵錯處理：當接收端收到區段(Segment)時，會檢查區段編號，若有遺失，就會發出錯誤訊息告知，或要求重送。
```
# 5 會議層 Session Layer
```
● 會議層（Session Layer）負責在資料傳輸中設定和維護電腦網路中兩台電腦之間的通訊連接。
  ─ 為傳輸雙方建立連線，並協調傳輸時所要遵循的規則。例如：全雙工、半雙工傳輸。
```
# 6 表達層 Presentation Layer
```
● 表達層（Presentation Layer）把資料轉換為能與接收者的系統格式相容並適合傳輸的格式。

  ─ 表達層能為不同的用戶端提供資料語法的轉換，使系統能解讀正確的資料。同時亦提供加密/解密、壓縮/解壓縮的功能。

  ─ 格式轉換：如傳送端用Unicode碼，接收端用EBCDIC碼，傳送端就必須在表達層中將資料轉換成接收端可識別的格式。

  ─ 加密解密：為避免資料在傳送過程中被窺探，可在傳送端作加密的動作，待送達接收端時，再作解密的動作。也算是另類的格式轉換。

  ─ 壓縮解壓縮：壓縮可使資料在傳輸過程中更具有效率。所以，同樣的，可在傳送端作壓縮的動作，送達接收端後，再作解壓縮的動作。
    也算是另類的格式轉換。
```
# 7 應用層 Application Layer
```
● 應用層（Application Layer）提供為應用軟體而設的介面，以設定與另一應用軟體之間的通訊。
  例如: HTTP，HTTPS，FTP，TELNET，SSH，SMTP，POP3.HTML.等。

  ─ 應用層能與應用程式作溝通，使用者介面，使User可以使用網路資源。
```
# Protocol (通訊協定)
```
● 所謂的『Protocol』是指在網路上一種可以彼此溝通的模式，雙方都要依照某些規則進行溝通。

● 電信中是指在任何物理媒介中允許兩個或多個在傳輸系統中的終端之間傳播資訊的系統標準，也是指電腦通信或網路裝置的共同語言。
  [1]通信協定定義了通信中的語法學, 語意學和同步規則以及可能存在的錯誤檢測與糾正。
     通信協定在硬體，軟體或兩者之間皆可實現
  [2]為了交換大量資訊，通信系統使用通用格式（協定）。每條資訊都有明確的意義使得預定位置給予回應，並獨立實施回應指定的行為
     ，通信協定須參與實體都同意才能生效。

● 在Internet 上也有彼此共同的語言，概稱為Protocol，但依照不同的需求，也有不同的通訊協定，例如要瀏覽網站的話，
  要遵守網站的通訊協定，叫http(HyperText  Transfer Protocol)；而要傳輸檔案，則要遵循ftp(File Transfer Protocol)，
  這個就是傳輸檔案專用的，也因為有了Protocol，Internet 的世界大同理想才得 以實現……
```
# 協定列表
|                 |        |      |        |    |     |  |   |       |
| -------------   | ------ |------|--------|----|---- |-- |- | ----  |
|ARP              |        |      |        |    |     |  |   |       |
|BGP|Bluetooth    |BOOTP   |Bonjour        |    |     |  |   |       |
|CAN|             |        |      |        |    |     |  |   |       |
|DHCP             |DNS     | DVMRP|DDNS    |    |     |  |   |       |
|EGP|             |        |      |        |    |     |  |   |       |
|FTP| FTPS        |        |      |        |    |     |  |   |       |
|Gopher           |        |      |        |    |     |  |   |       |
|HDLC             |HELLO   |HTTP  |HTTPS   |    |     |  |   |       |
|ICMP             |IDRP    |IEEE 802 |IGMP |IGP |IMAP |IP| IPX| IS-IS|
|LCP              |LLC     |      |   |    |    |     |  |    |      |
|MLD              |        |      |   |    |    |     |  |    |      |
|NCP              |NNTP    |NTP   |   |    |    |     |  |    |      |
|PPP              |POP     |      |   |    |    |     |  |    |      |
|RARP             |RIP     |RTP   |RTSP|    |    |     |  |    |      |
|SLIP             |SNMP    |SMTP  |SOCKS|SPDY|    |     |  |    |      |
|TCP              |TFTP    |Telnet|     |    |    |     |  |    |      |
|UDP              |        |      |   |    |    |     |  |    |      |
|X.25             |        |      |   |    |    |     |  |    |      |
|Yahoo!奇摩即時通 通訊協定|        |      |   |    |    |     |  |    |      |
```
● ARP
  位址解析協定（英語：Address Resolution Protocol，縮寫：ARP）
  是一個通過解析網路層位址來找尋資料鏈路層位址的網路傳輸協定，它在IPv4中極其重要。
  
  來查問欲傳送之目的主機的MAC位址==已知的 IP 位址查問其相對應的網路實體位
  反向位址解析協定（Reverse Address Resolution Protocol, RARP）。由已知的網路實體位址查詢其相對應的 IP 位址
  
  ARP是通過網路位址來定位MAC位址。
  
● MAC  
  MAC位址（英語：Media Access Control Address）
  直譯為媒體存取控制位址，也稱為區域網路位址（LAN Address），乙太網路位址（Ethernet Address）
  或實體位址（Physical Address），它是一個用來確認網路裝置位置的位址。

  ─ 在OSI模型中，第三層網路層負責IP位址，第二層資料鏈結層則負責MAC位址。
  ─ MAC位址用於在網路中唯一標示一個網卡，一台裝置若有一或多個網卡，則每個網卡都需要並會有一個唯一的MAC位址。
● BGP
  邊界閘道器協定（英語：Border Gateway Protocol，縮寫：BGP）
  是網際網路上一個核心的去中心化自治路由協定。

  它通過維護IP路由表或『字首』表來實現自治系統（AS）之間的可達性，屬於向量路由協定。
  BGP不使用傳統的內部網路關協定（IGP）的指標，而使用基於路徑、網路策略或規則集來決定路由。
  因此，它更適合被稱為向量性協定，而不是路由協定。

● Bluetooth
  藍牙（英語：Bluetooth）
  一種無線通訊技術標準，用來讓固定與行動裝置，在短距離間交換資料，以形成個人區域網路（PAN）。
  其使用短波超高頻（UHF）無線電波，經由2.4至2.485 GHz的ISM頻段來進行通信。

  藍牙協定堆疊
  藍牙協定堆疊依照其功能可分四層：

  核心協定層（HCI、LMP、L2CAP、SDP）
  線纜替換協定層（RFCOMM）
  電話控制協定層（TCS-BIN）
  選用協定層（PPP、TCP、IP、UDP、OBEX、IrMC、WAP、WAE）

  ─ 干擾
  Bluetooth在2.4GHz的電波干擾問題一直為大家所詬病，特別和無線區域網路間的互相干擾問題。
  有干擾發生時，就以重新傳送封包的方法來解決干擾。

  ─ 安全性
  在JAVA和Symbian60平台上，使用「藍牙駭客」或「藍牙間諜」軟體，無需配對就可以控制開啟藍牙的手機。
  此種軟體可以實現的功能有：檢視對方手機中的電話簿、簡   訊、電量、序列號；更改對方手機的音訊設定檔和介面語言、
  開啟對方手機內建的JAVA軟體、控制手機多媒體播放器、遙控對方手機打電話、傳簡訊等。

● DHCP
  動態主機設定協定（英語：Dynamic Host Configuration Protocol，縮寫：DHCP）
  是一個用於區域網路的網路協定，位於OSI模型的應用層，使用UDP協定工作，主要有兩個用途：

  ─ 用於內部網路或網路服務供應商自動分配IP位址給用戶
  ─ 用於內部網路管理員對所有電腦作中央管理
  
● DNS
  網域名稱系統（英語：Domain Name System，縮寫：DNS）
  是網際網路的一項服務。它作為將域名和IP位址相互對映的一個分散式資料庫，能夠使人更方便地存取網際網路。
  
  ─ DNS使用TCP和UDP埠53[1]。目前，對於每一級域名長度的限制是63個字元，域名總長度則不能超過253個字元。

● FTP(21)
  檔案傳輸協定（英語：File Transfer Protocol，縮寫：FTP）
  是一個用於在電腦網路上在客戶端和伺服器之間進行檔案傳輸的應用層協定。
  檔案傳送（file transfer）和檔案存取（file access）之間的區別在於：前者由FTP提供，後者由如NFS等應用系統提供。

  ─ FTP服務一般執行在20和21兩個埠。埠20用於在客戶端和伺服器之間傳輸資料流，而埠21用於傳輸控制流，
    並且是命令通向ftp伺服器的進口。

● FTP不是一項安全的協定，並且具有許多安全漏洞[2]。1999年5月發布的RFC 2577中列出了以下幾個主要的漏洞：
  ─ 蠻力攻擊
  ─ FTP反彈攻擊
  ─ 封包擷取
  ─ 埠竊取（猜測下一個開放埠並篡奪合法連接）
  ─ 欺騙攻擊
  ─ 用戶名稱列舉
● 通過FTP傳輸的流量不會被加密，所有傳輸通過明文進行的。
  任何能夠在網路上執行封包擷取（ 嗅探 ）的人都可以讀取用戶名稱、密碼、命令內容和資料。
  此問題在加密機制（如TLS或SSL）產生之前的許多Internet協定規範（如SMTP 、Telnet 、POP和IMAP）中較為普遍。

  此問題的常見解決方案包括：
  ─ 使用協定的安全版本，例如FTPS而不是FTP，TelnetS而不是Telnet。
  ─ 使用可以處理作業的不同的，更安全的協定，例如 SSH檔案傳輸協定或安全複製協定 。
  ─ 使用安全隧道（如Secure Shell或虛擬私人網路 ）。

● FTPS(21)
  FTPS是一種對常用的檔案傳輸協定（FTP）添加傳輸層安全（TLS）和安全通訊協定（SSL）加密協定支援的擴充協定。

● HTTP(80)
  超文本傳輸協定（英語：HyperText Transfer Protocol，縮寫：HTTP）
  是一種用於分佈式、協作式和超媒體訊息系統的應用層協定。HTTP是全球資訊網的資料通信的基礎。

  HTTP是一個客戶端（用戶）和伺服器端（網站）之間請求和應答的標準，通常使用TCP協定。
  透過使用網頁瀏覽器、網路爬蟲或者其它的工具，客戶端發起一個HTTP請求到伺服器上指定埠（預設埠為80）。

● HTTPS(443)
  超文本傳輸安全協定（英語：HyperText Transfer Protocol Secure，
  縮寫：HTTPS；常稱為HTTP over TLS、HTTP over SSL或HTTP Secure）
  是一種透過計算機網路進行安全通訊的傳輸協定。HTTPS經由HTTP進行通訊，但利用SSL/TLS來加密封包。
  
  ─ HTTPS開發的主要目的，是提供對網站伺服器的身分認證，保護交換資料的隱私與完整性。
  
● 主要作用
  HTTPS的主要作用是在不安全的網路上建立一個安全信道，並可在使用適當的加密套件和伺服器憑證可被驗證且
  可被信任時，對竊聽和中間人攻擊提供合理的防護。
  
  ─ 此協定的加密層（SSL/TLS）能夠有效地提供認證和高強度的加密。
  
● ICMP
  網際網路控制訊息協定（英語：Internet Control Message Protocol，縮寫：ICMP）
  是網際網路協定套組的核心協定之一。
  
  它用於網際網路協定（IP）中傳送控制訊息，提供可能發生在通訊環境中的各種問題回饋。
  通過這些資訊，使管理者可以對所發生的問題作出診斷，然後採取適當的措施解決。
  
  ─ ICMP 依靠IP來完成它的任務，它是IP的主要部分。它與傳輸協定（如TCP和UDP）顯著不同：它一般不用於在兩點間傳輸資料。
  
● IEEE 802
  IEEE 802 指IEEE標準中關於區域網路和都會網路的一系列標準。
  更確切的說，IEEE 802標準僅限定在傳輸可變大小封包的網路。其中最廣泛使用的有乙太網路、權杖環、無線區域網路等。
  
● IEEE 802中定義的服務和協定限定在OSI模型的最低兩層（即實體層和資料鏈路層）。
  事實上，IEEE 802將OSI的資料鏈路層分為兩個子層，分別是
  邏輯鏈路控制（LLC, Logical Link Control）和
  媒介存取控制（MAC, Media Access Control）
  如下所示：

● 資料鏈路層(Layer-2)
  ─ 邏輯鏈路控制子層
  ─ 媒介存取控制子層
● 實體層(Layer-1)  
   
● LLC
  邏輯鏈路控制（英語：Logical Link Control，簡稱LLC）
  是區域網中數據鏈路層的上層部分，IEEE 802.2中定義了邏輯鏈路控制協議。
  用戶的數據鏈路服務透過LLC子層為網絡層提供統一的接口。
  在LLC子層下面是MAC（介質訪問控制）子層。
  
  LLC提供了兩種無連接和一種面向連接的三種操作方式：

  方式一：無回復的非連接導向方式，它允許發送幀時：

  ─ 給單一的目的地址（點到點協議或單點傳輸）；
  ─ 給相同網絡中的多個目的地址（多點傳輸）；
  ─ 給網絡中的所有地址（廣播傳輸）。
    多點和廣播傳輸在同一信息需要發送到整個網絡的情況下可以減少網絡流量。
    單點傳輸不能保證接收端收到幀的次序和發送時的次序相同。發送端甚至無法確定接收端是否收到了幀。

  方式二：面向連接的操作方式。給每個幀進行編號，接收端就能保證它們按發送的次序接收，並且沒有幀丟失。
  利用滑動窗口流控制協議可以讓快的發送端也能流到慢的接收端。

  方式三：有回覆的無連接方式。它僅限於點到點通信。
  
● MAC
  媒體存取控制（英語：Media Access Control，縮寫：MAC）
  子層，是區域網路中資料鏈路層的下層部分，提供定址及媒體存取的控制方式，使得不同裝置或網路上的節點可以在
  多點的網路上通訊，而不會互相衝突。
  
  ─ MAC子層作為邏輯鏈路控制子層及物理層之間溝通的媒介，提供了一種定址的方法，稱為實體位址或MAC位址。
  ─ MAC常用作多路存取（multiple access）協定的同義詞。因為MAC提供配合特定通道存取（channel access method）
    需要的協定及控制機制。
    
 ● 區域網路用的協定:
   ***IEEE 802.3：乙太網路（Ethernet）***
      IEEE 802.4：權杖匯流排（Token bus）
      IEEE 802.5：權杖環（Token-Ring） 
    
  
  
● IEEE 802 現有標準
  ─ IEEE 802.1：高層區域網路協定（Bridging (networking) and Network Management）
  ─ IEEE 802.2：邏輯鏈路控制（Logical link control）
  ─ IEEE 802.3：乙太網路（Ethernet）
  ─ IEEE 802.4：權杖匯流排（Token bus）
  ─ IEEE 802.5：權杖環（Token-Ring）
  ─ IEEE 802.6：城域網（MAN, Metropolitan Area Network）
  ─ IEEE 802.7：寬頻TAG（Broadband LAN using Coaxial Cable）
  ─ IEEE 802.8：光纖分散式資料介面（FDDI）
  ─ IEEE 802.9：綜合業務區域網路（Integrated Services LAN）
  ─ IEEE 802.10：區域網路網路安全（Interoperable LAN Security）
  ─ IEEE 802.11：無線區域網路（Wireless LAN & Mesh）
  ─ IEEE 802.12：需求優先級（Demand priority）
  ─ IEEE 802.13：（未使用）
  ─ IEEE 802.14：電纜數據機（Cable modems）
  ─ IEEE 802.15：無線個人區域網路（Wireless PAN）
  ─ IEEE 802.15.1：無線個人區域網路絡（WPAN, Wireless Personal Area Network）
  ─ IEEE 802.15.4：低速無線個人區域網路絡（LR-WPAN, Low Rate Wireless Personal Area Network）
  ─ IEEE 802.16：寬頻無線接入（Broadband Wireless Access）
  ─ IEEE 802.17：彈性封包環傳輸技術（Resilient packet ring）
  ─ IEEE 802.18：無線電管制技術（Radio Regulatory TAG）
  ─ IEEE 802.19：共存標籤（Coexistence TAG）
  ─ IEEE 802.20：移動寬頻無線接入（Mobile Broadband Wireless Access）
  ─ IEEE 802.21：媒介獨立換手（Media Independent Handover）
  ─ IEEE 802.22：無線區域網（Wireless Regional Area Network）
  ─ IEEE 802.23：緊急服務工作群組（Emergency Services Working Group），2010年3月新發布
  
● IP 
  網際網路協議（英語：Internet Protocol Suite，縮寫IPS）
  是一個網路通訊模型，以及一整個網路傳輸協定家族，為網際網路的基礎通訊架構。
  
  它常被通稱為TCP/IP協定套組（英語：TCP/IP Protocol Suite，或TCP/IP Protocols），簡稱TCP/IP。
  因為該協定家族的兩個核心協定：TCP（傳輸控制協定）和IP（網際網路協定），為該家族中最早通過的標準。
  由於在網路通訊協定普遍採用分層的結構，當多個層次的協定共同工作時，類似電腦科學中的堆疊，因此又被稱為
  TCP/IP協定疊（英語：TCP/IP Protocol Stack）。
  
● 下面的圖表試圖顯示不同的TCP/IP和其他的協定在最初OSI模型中的位置：
  應用層
  application layer  例如HTTP、SMTP、SNMP、FTP、Telnet、SIP、SSH、NFS、RTSP、XMPP、Whois、ENRP、TLS
  
  表現層
  presentation layer 例如XDR、ASN.1、SMB、AFP、NCP
  
  會議層
  session layer      例如ASAP、ISO 8327 / CCITT X.225、RPC、NetBIOS、ASP、IGMP、Winsock、BSD sockets 
  
  傳輸層
  transport layer    例如TCP、UDP、RTP、SCTP、SPX、ATP、IL
  
  網路層
  network layer      例如IP、ICMP、IPX、BGP、OSPF、RIP、IGRP、EIGRP、ARP、RARP、X.25
  
  資料連結層
  data link layer    例如乙太網路、權杖環、HDLC、影格中繼、ISDN、ATM、IEEE 802.11、FDDI、PPP 
  
  實體層
  physical layer     例如線路、無線電、光纖
  
  ─ 通常人們認為OSI模型的最上面三層（應用層、表現層和會議層）在TCP/IP組中是一個應用層。
    由於TCP/IP有一個相對較弱的會議層，由TCP和RTP下的開啟和關閉連接組成，並且在TCP和UDP下的各種應用提供不同的埠號
    ，這些功能能夠被單個的應用程式（或者那些應用程式所使用的庫）增加。
  ─ IP是按照將它下面的網路當作一個黑盒子的思想設計的，這樣在討論TCP/IP的時候就可以把它當作一個獨立的層。
  
  應用層
  application layer            例如HTTP、FTP、DNS
  
  傳輸層
  transport layer              例如TCP、UDP、RTP、SCTP
  
  網路互連層     
  internet layer               對於TCP/IP來說這是網際網路協定（IP）
                              （如ICMP和IGMP這樣的必須協定儘管執行在IP上，
                               也仍然可以看作是網路互連層的一部分；ARP不執行在IP上）

  網路存取(連結)層
  Network Access(link) layer   例如乙太網路、Wi-Fi、MPLS等。

● SNMP  SNMP為代理使用UDP埠161，為管理站使用UDP埠162。
  簡單網路管理協定（SNMP，Simple Network Management Protocol）
  構成了網際網路工程工作小組（IETF，Internet Engineering Task Force）定義的Internet協定族的一部分。
  該協定能夠支援網路管理系統，用以監測連接到網路上的裝置是否有任何引起管理上關注的情況。

  SNMP協定工作在OSI模型的應用層（第七層）。
  
● Telnet(23)
  Telnet是一種應用層協定，使用於網際網路及區域網中，使用虛擬終端機的形式，提供雙向、
  以文字字串為主的命令列介面互動功能。  
  
● 應用
  ─ 圖書館利用Telnet及全球資訊網供讀者進行續借、預約及查詢記錄的服務。
  ─ 多數的純文字式BBS仍使用Telnet，部分甚至提供SSH服務，以提升安全性。
  ─ 路由器、交換器及大部份的電信裝置仍提供Telnet及SSH介面，以讓管理者連入進行設定及維護。
  
● SSH
  Secure Shell（安全外殼協定，簡稱SSH）
  是一種加密的網路傳輸協定，可在不安全的網路中為網路服務提供安全的傳輸環境。
  
  SSH通過在網路中建立安全隧道來實現SSH客戶端與伺服器之間的連接。
  
  雖然任何網路服務都可以通過SSH實現安全傳輸，SSH最常見的用途是遠端登入系統，人們通常利用SSH來傳輸命令行
  介面和遠端執行命令。
  
  在設計上，SSH是Telnet和非安全shell的替代品。Telnet和Berkeley rlogin、rsh、rexec等協定採用明文傳輸，
  使用不可靠的密碼，容易遭到監聽、嗅探和中間人攻擊。
  ─ SSH旨在保證非安全網路環境（例如網際網路）中資訊加密完整可靠。
  
  SSH以非對稱加密實現身分驗證。
  身分驗證有多種途徑，例如其中一種方法是使用自動生成的公鑰-私鑰對來簡單地加密網路連接，隨後使用密碼認證進行登入
  另一種方法是人工生成一對公鑰和私鑰，通過生成的金鑰進行認證，這樣就可以在不輸入密碼的情況下登入。
  
  SSH協定框架中最主要的部分是三個協定：

  ─ 傳輸層協定（The Transport Layer Protocol）：傳輸層協定提供伺服器認證，資料機密性，資訊完整性等的支援。
  ─ 用戶認證協定（The User Authentication Protocol）：用戶認證協定為伺服器提供客戶端的身分鑑別。
  ─ 連接協定（The Connection Protocol）：連接協定將加密的資訊隧道復用成若干個邏輯通道，提供給更高層的應用協定使用。
  
● XMPP
  可延伸訊息與存在協定（英語：Extensible Messaging and Presence Protocol，縮寫：XMPP；前稱Jabber）
  是一種以XML為基礎的開放式即時通訊協定，是經由網際網路工程工作小組（IETF）通過的網際網路標準。

● 特色
● 優點
● 開放
  ─ XMPP協議是自由、開放、公開的，並且易於瞭解。而且在客戶端、伺服器、元件、原始碼庫等方面，都已經各自有多種實作。
  證實可用
  ─ 第一個Jabber（現在XMPP）技術是Jeremie Miller在1998年開發的，現在已經相當穩定；數以百計的開發者為XMPP技術而努力。
    今日的網際網路上有數以萬計的XMPP伺服器運作著，並有數以百萬計的人們使用XMPP即時傳訊軟體。
  分散式
  ─ XMPP網路的架構和電子郵件十分相像；XMPP核心協定通信方式是先建立一個stream，XMPP以TCP傳遞XML資料流，沒有中央主伺服器。
    任何人都可以運行自己的XMPP伺服器，使個人及組織能夠掌控他們的即時傳訊體驗。
  安全
  ─ 任何XMPP協定的伺服器可以獨立於公眾XMPP網路（例如在企業內部網路中），而使用SASL及TLS等技術的可靠安全性，已內建於核心XMPP
    技術規格中。
  可擴展
  ─ XML命名空間的威力可使任何人在核心協定的基礎上建造客製化的功能；為了維持通透性，常見的擴充套件由XMPP標準基金會。
  彈性佳
  ─ XMPP除了可用在即時通訊的應用程式，還能用在網路管理、內容供稿、協同工具、檔案共享、遊戲、遠端系統監控等。
  多樣性
  ─ 用XMPP協定來建造及布署即時應用程式及服務的公司及開放原始碼計劃分布在各種領域；用XMPP技術開發軟體，
    資源及支援的來源是多樣的，使得使你不會陷於被「綁架」的困境。

● 缺點
資料負載太重 
  ─ 隨著通常超過70％的XMPP協定的伺服器的資料流量的存在和近60％的被重複轉發，XMPP協定目前擁有一個大型架空中存在的資料提供給多個
    收件人。新的議定書正在研究，以減輕這一問題。
二進制資料傳輸受限 
  ─ XMPP傳輸單一的XML檔案，因此要透過XMPP傳輸二進制資料，需先將二進制資料以Base64編碼。但是大量的二進制資料傳輸，較佳的作法是
    用外部的其他協定傳輸，而以XMPP進行溝通。至於其他二進制資料加密會話（encrypted conversations）或圖形圖標（graphic icons）
    以嵌入式使用相同的方法。
    
● XMPP協定的另一功能是運輸（transports），也被稱為網關（gateways），可允許用戶透過網路使用其它協定。
  這可以是其他的即時通訊協定，也可以是不同協定，如簡訊（SMS）或電子郵件。
  
● 由於客戶端使用HTTP，大多數防火牆允許客戶端獲取和留言沒有任何障礙。因此，即使使用XMPP協定的TCP埠被攔截，伺服器也能正常地傾聽一般
  的HTTP埠，其上的訊息也能保持暢通。還有一些網站更允許大眾經由瀏覽器登入進XMPP。
  
  ─ 尤有甚者，還有一些公共的伺服器同時擁有標準HTTP（80埠）和HTTPS（443埠），因此又有助於通過防火牆。  
  
● POP
 郵局協議（英語：Post Office Protocol，縮寫：POP）
 是TCP/IP協定族中的一員，由RFC 1939定義。此協定主要用於支援使用客戶端遠端管理在伺服器上的電子郵件。
  
 ─ 最新版本為POP3，全名「Post Office Protocol - Version 3」，而提供了SSL加密的POP3協定被稱為POP3S。 
  
 ─ POP支援離線郵件處理。其具體過程是：郵件傳送到伺服器上，電子郵件客戶端呼叫郵件客戶機程式以連接伺服器，並下載所有未閱讀的
   電子郵件。這種離線存取模式是一種儲存轉發服務，將郵件從郵件伺服器端送到個人終端機器上，一般是PC機或MAC。 
  
● RIP 
  路由資訊協定（英語：Routing Information Protocol，縮寫：RIP）
  是一種內部網路關協定（IGP），為最早出現的距離向量路由協定。
  
  屬於網路層，其主要應用於規模較小的、可靠性要求較低的網路，可以通過不斷的交換資訊讓路由器動態的適應網路連接的變化，
  這些資訊包括每個路由器可以到達哪些網路，這些網路有多遠等。
  
 ─ 雖然RIP仍然經常的被使用，但是由於收斂慢和支援的廣播網路規模有限等缺點，許多人認為它將會而且正在被諸如OSPF和IS-IS
   這樣的路由協定所取代。
  
  每隔30秒會與相鄰的路由器交換子訊息，以動態的建立路由表。
  
● 防止網路環路
  由於路由器可能收到它自己傳送的路由資訊而造成網路環路，為了提高RIP協定效能而使用以下措施：

 ─ 水平分割：水平分割指的是RIP從某個介面學到的路由，不會從該介面再發回給鄰居裝置。在影格中繼和X.25等NBMA網路中，
   水平分割功能預設為禁止狀態。
   
 ─ 毒性逆轉：毒性逆轉指的是RIP從某個介面學到路由後，將該路由的開銷設定為16（即指明該路由不可達），並從原介面發回鄰居裝置。
 
 ─ 抑制定時器
 
 ─ 觸發更新：觸發更新是指路由資訊發生變化時，立即向鄰居裝置傳送觸發更新報文，通知變化的路由資訊。
 （觸發更新不會觸發接收路由器重設自己的更新定時器）
  
● RIPv2 使用UDP埠520和多播位址224.0.0.9通信，RIPng 則使用UDP埠521和多播位址FF02::9通信
  
● SMTP (25， 587， 465)
  簡單郵件傳輸協定（英語：Simple Mail Transfer Protocol，縮寫：SMTP）
  是一個在網際網路上傳輸電子郵件的標準。
  
  SMTP是一個相對簡單的基於文字的協定。在其之上指定了一條訊息的一個或多個接收者（在大多數情況下被確認是存在的），
  然後訊息文字會被傳輸。可以很簡單地通過telnet程式來測試一個SMTP伺服器。
  
 ─ SMTP使用TCP埠25。要為一個給定的域名決定一個SMTP伺服器，需要使用DNS的MX記錄。

● SMTP安全和垃圾郵件
 ─ 最初的SMTP的局限之一在於它沒有對傳送方進行身分驗證的機制。因此，後來定義了SMTP-AUTH擴充。

 ─ 儘管有了身分認證機制，垃圾郵件仍然是一個主要的問題。但由於龐大的SMTP安裝數量帶來的網路效應，大刀闊斧地修改或完全替代
   SMTP被認為是不現實的。Internet Mail 2000就是一個替代SMTP的建議方案。

 ─ 因此，出現了一些同SMTP工作的輔助協定。IRTF的反垃圾郵件研究小組正在研究一些建議方案，以提供簡單、靈活、輕量級的、
   可升級的源端認證。最有可能被接受的建議方案是發件人策略框架協定。
  
● TFTP (69)  
  簡單檔案傳輸協定也稱小型檔案傳輸協定（Trivial File Transfer Protocol, TFTP）
  是一種於1981年在RFC 783中定義的簡化的檔案傳輸協定（FTP）。
  
─ 小型檔案傳輸協定非常簡單，透過少量記憶體就能輕鬆實現——這在當時是很重要的考慮因素。

  所以TFTP被用於啟動電腦，例如沒有大容量記憶體的路由器。
  
  現在它仍然被用於在一個網路上主機之間傳輸小檔案，例如從一台網路主機或伺服器啟動一個遠端X Window System終端或其他的瘦
  客戶端。
  
● 技術資訊
  小型檔案傳輸協定的一些詳細資料：
 ─ 使用UDP（埠69）作為其傳輸協定（不像FTP使用TCP埠21）。
 ─ 不能列出目錄內容。
 ─ 無驗證或加密機制。
 ─ 被用於在遠端伺服器上讀取或寫入檔案。
 ─ 支援三種不同的傳輸模式："netascii","octet"和"mail"，前兩種符合FTP協定中的"ASCII"和"image（binary）"模式；
   第三種從來很少使用，目前已經廢棄。
  
● 因為小型檔案傳輸協定使用UDP協定，就必須自己支援傳輸和對談的控制。每個通過TFTP傳輸的檔案構成了一個獨立的交換。
  此傳輸表現為步鎖，任何時間網路上僅僅傳遞一個包（一個資料塊或一個首部確認）。由於缺少窗口切換技術，TFTP在有很多潛在連接的
  情況下僅提供較低的吞吐量。

  由於小型檔案傳輸協定缺少安全性，在開放式網際網路上傳輸非常危險，所以普遍僅僅用於私人本地網路。目前TFTP常用於PXE無盤啟動
  ，網路裝置的設定等。
  
● TCP
  傳輸控制協定（英語：Transmission Control Protocol，縮寫：TCP）
  是一種連接導向的、可靠的、基於位元組流的傳輸層通信協定，由IETF的RFC 793定義。在簡化的電腦網路OSI模型中，
  它完成第四層傳輸層所指定的功能。用戶資料報協定（UDP）是同一層內另一個重要的傳輸協定。
  
─ 在網際網路協定族（Internet protocol suite）中，TCP層是位於IP層之上，應用層之下的中間層。
  不同主機的應用層之間經常需要可靠的、像管道一樣的連接，但是IP層不提供這樣的流機制，而是提供不可靠的包交換。
  
● 應用層向TCP層傳送用於網間傳輸的、用8位元位元組表示的資料流，然後TCP把資料流分割成適當長度的報文段
  （通常受該電腦連接的網路的資料鏈路層的最大傳輸單元（MTU）的限制）。
  
  之後TCP把結果包傳給IP層，由它來透過網路將包傳送給接收端實體的TCP層。TCP為了保證不發生丟包，就給每個包一個序號，
  同時序號也保證了傳送到接收端實體的包的按序接收。然後接收端實體對已成功收到的包發回一個相應的確認資訊（ACK）；
  如果傳送端實體在合理的往返時延（RTT）內未收到確認，那麼對應的封包就被假設為已遺失並進行重傳。TCP用一個校驗和函式來
  檢驗資料是否有錯誤，在傳送和接收時都要計算校驗和。
  
● 資料傳輸
  在TCP的資料傳送狀態，很多重要的機制保證了TCP的可靠性和強壯性。
  它們包括：使用序號，對收到的TCP報文段進行排序以及檢測重複的資料；使用校驗和檢測報文段的錯誤，即無錯傳輸
  使用確認和計時器來檢測和糾正丟包或延時；流控制（Flow control）；擁塞控制（Congestion control）；遺失包的重傳。
  
● 可靠傳輸
  可靠性通過傳送方檢測到遺失的傳輸資料並重傳這些資料。包括超時重傳（Retransmission timeout，RTO）與重複累計確認
  （duplicate cumulative acknowledgements，DupAcks）。
  
● 流量控制
  流量控制用來避免主機分組傳送得過快而使接收方來不及完全收下，一般由接收方通告給傳送方進行調控。

  TCP使用滑動窗口協定實現流量控制。接收方在「接收窗口」域指出還可接收的位元組數量。
  傳送方在沒有新的確認包的情況下至多傳送「接收窗口」允許的位元組數量。接收方可修改「接收窗口」的值。
  
● UDP
  用戶資料包協定（英語：User Datagram Protocol，縮寫：UDP；又稱用戶資料报協定）
  是一個簡單的面向資料報的通信協定，位於OSI模型的傳輸層。
  
● 在TCP/IP模型中，UDP為網路層以上和應用層以下提供了一個簡單的介面。UDP只提供資料的不可靠傳遞，
  它一旦把應用程式發給網路層的資料傳送出去，就不保留資料備份（所以UDP有時候也被認為是不可靠的資料報協定）。
  UDP在IP資料報的頭部僅僅加入了復用和資料校驗欄位。
  
● UDP適用於不需要或在程式中執行錯誤檢查和糾正的應用，它避免了協定棧中此類處理的開銷。
  對時間有較高要求的應用程式通常使用UDP，因為丟棄封包比等待或重傳導致延遲更可取。
  
● 可靠性
  由於UDP缺乏可靠性且屬於無連接協定，所以應用程式通常必須容許一些遺失、錯誤或重複的封包。
  某些應用程式（如TFTP）可能會根據需要在應用程式層中添加基本的可靠性機制。
  
  
  ─ 一些應用程式不太需要可靠性機制，甚至可能因為引入可靠性機制而降低效能，所以它們使用UDP這種缺乏可靠性的協定。
    串流媒體，即時多人遊戲和IP語音（VoIP）是經常使用UDP的應用程式。 在這些特定應用中，丟包通常不是重大問題。
    如果應用程式需要高度可靠性，則可以使用諸如TCP之類的協定。
  
● 語音和影片流量通常使用UDP傳輸。 即時影片和音訊流應用程式旨在處理偶爾遺失、錯誤的封包，因此只會發生品質輕微下降，
  而避免了重傳封包帶來的高延遲。 由於TCP和UDP都在同一網路上執行，因此一些企業發現來自這些即時應用程式的UDP流量影響了使用TCP
  的應用程式的效能，例如銷售、會計和資料庫系統。 當TCP檢測到封包遺失時，它將限制其資料速率使用率。
```
```
● RARP
  逆位址解析協定（Reverse Address Resolution Protocol，RARP）
  是一種網路協定，網際網路工程任務組（IETF）在RFC903中描述了RARP。RARP使用與ARP相同的報頭結構，作用與ARP相反。
  
  ─ RARP用於將MAC位址轉換為IP位址。其因為較限於IP位址的運用以及其他的一些缺點，因此漸為更新的BOOTP或DHCP所取代。

● 工作原理
  ─ 傳送主機傳送一個原生的RARP廣播，在此廣播包中，聲明自己的MAC位址並且請求任何收到此請求的RARP伺服器分配一個IP位址；
  ─ 本地網段上的RARP伺服器收到此請求後，檢查其RARP列表，尋找該MAC位址對應的IP位址；
  ─ 如果存在，RARP伺服器就給源主機傳送一個回應封包並將此IP位址提供給對方主機使用；
  ─ 如果不存在，RARP伺服器對此不做任何的回應；
  ─ 源主機收到從RARP伺服器的回應資訊，就利用得到的IP位址進行通訊；如果一直沒有收到RARP伺服器的回應資訊，表示初始化失敗。
```
# ICMP
```
● ICMP
  網際網路控制訊息協定（英語：Internet Control Message Protocol，縮寫：ICMP）
  是網際網路協定套組的核心協定之一。
  
  它用於網際網路協定（IP）中傳送控制訊息，提供可能發生在通訊環境中的各種問題回饋。
  通過這些資訊，使管理者可以對所發生的問題作出診斷，然後採取適當的措施解決。
  
  ─ ICMP 依靠IP來完成它的任務，它是IP的主要部分。它與傳輸協定（如TCP和UDP）顯著不同：它一般不用於在兩點間傳輸資料。
  
  ─ 在 IP 網路上，任何一部主機或路由器皆設置有 ICMP 協定，它們就可以利用 ICMP 來互相交換網路目前的狀況訊息。
    例如，主機不存在、網路斷線等等狀況。
```
# ICMP Message Format封包格式:
![ICMP封包格式](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/Network/icmp_header.gif)
```
● (1) 訊息型態（Message Type）：表示該 ICMP 所欲控制之訊息型態，共有 13 種型態，訊息型態之型態代表值如表 13-2 所示。

● (2) 編碼（Code）：對各種訊息型態進一步說明工作內容。

● (3) 檢查集檢查碼（Checksum）：對該封包檢查集錯誤偵測。

● (4) 訊息說明（Message description）：依照不同的控制訊息，而有不同的說明方式。

● (5) 訊息資料（Message Data）：依照不同的控制訊息，而有不同的資料表示。

● ICMP 在溝通之中，主要是透過不同的類別( Type )與代碼( Code ) 讓機器來識別不同的連線狀況。
  常用的類別如下表所列﹕
  
 類別	名稱	代表意思
  
● ***0	Echo Reply	是一個回應信息。***（回應答覆）

● ***3	Distination Unreachable	表示目的地不可到達。***（目的地無法到達）

● 4	Source Quench	當 router 負載過時﹐用來竭止來源繼續發送訊息。（來源抑制）

● ***5	Redirect	用來重新導向路由路徑。***（改變傳輸路徑）

● ***8	Echo Request	請求回應訊息。***（回應要求）

● 9 Router Advertisement（路由器宣傳）
● 10 Router Solicitation（路由器懇請）
● 11	Time Exeeded for a Datagram	當資料封包在某些路由現象中逾時﹐告知來源該封包已被忽略忽略。（路由器宣傳）
● 12	Parameter Problem on a Datagram	當一個 ICMP 封包重複著之前的錯誤時﹐會回覆來源主機關於參數錯誤的訊息。（參數問題）
● 13	Timestamp Request	要求對方送出時間訊息﹐用以計算路由時間的差異﹐以滿足同步性協定的要求。（時間標籤要求）
● 14	Timestamp Replay	此訊息純粹是回應 Timestamp Request 用的。（時間標籤回覆）
● 15	Information Request	在 RARP 協定應用之前﹐此訊息是用來在開機時取得網路信息。（資訊要求）（停用）
● 16	Information Reply	用以回應 Infromation Request 訊息。（資訊回覆）（停用）
● 17	Address Mask Request	這訊息是用來查詢子網路 mask 設定信息。（位址遮罩要求）
● 18	Address Mask Reply	回應子網路 mask 查詢訊息的。（位址遮罩回覆）


● 在 ICMP 使用中﹐不同的類別會以不同的代碼來描述具體的狀況。以 Type 3 ( Distination Unreachable ) 
  為例，其下的代碼如下所列﹕
  
  代碼	代表意思
  0  	 Network Unreachable（無法到達目的網路）
  1	   Host Unreachable（無法到達目的主機）
  2	   Protocol Unreachable（通訊協定不存在）
  3	   Port Unreachable（無法到達連接埠）
  4	   Fragmentation Needed and DF set（資料需分割並設定不可分割位元）
  5    Source Route Failed（來源路徑選擇失敗）
  6	   Destination network unknown（無法識別目的地網路）
  7	   Destination host unknown（無法識別目的地主機）
  8	   Source host isolated（來源主機被隔離）
  9	   Communication with destination network administraively prohibited（管理上禁止和目的地網路通訊）
  10	 Communication with destination host administraively prohibited（管理上禁止和目的地主機通訊）
  11	 Network unreachable for type of service（無法到達此型態的網路服務）
  12	 host unreachable for type of service（無法到達此型態的主機服務）
```
# ICMP 封裝
![ICMP 封裝](https://github.com/ChengHan16/Cs4high_4080E036/blob/master/Network/image/icmp_encap%E5%B0%81%E8%A3%9D.gif)
```



























```
Network Types: LAN, WAN, PAN, CAN, MAN, SAN, WLAN
https://www.youtube.com/watch?v=4_zSIXb7tLQ
```
```
Network Topologies (Star, Bus, Ring, Mesh, Ad hoc, Infrastructure, & Wireless Mesh Topology)
https://www.youtube.com/watch?v=zbqrNg4C98U
```

```
What is a DMZ? (Demilitarized Zone)
https://www.youtube.com/watch?v=dqlzQXo1wqo
```
```
NAT Explained - Network Address Translation
https://www.youtube.com/watch?v=FTUV0t6JaDA
```

# IEEE 802
```
● IEEE 802 指IEEE標準中關於區域網路和都會網路的一系列標準。更確切的說，IEEE 802標準僅限定在傳輸可變大小封包的網路。
  其中最廣泛使用的有乙太網路、權杖環、無線區域網路等。這一系列標準中的每一個子標準都由委員會中的一個專門工作群組負責。

● IEEE 802中定義的服務和協定限定在OSI模型的最低兩層（即實體層和資料鏈路層）。
  事實上，IEEE 802將OSI的資料鏈路層分為兩個子層，分別是邏輯鏈路控制（LLC, Logical Link Control）和媒介存取控制
 （MAC, Media Access Control），如下所示：
● 資料鏈路層
●   邏輯鏈路控制子層
●   媒介存取控制子層
● 實體層

現有標準
IEEE 802.1：高層區域網路協定（Bridging (networking) and Network Management）
IEEE 802.2：邏輯鏈路控制（Logical link control）

IEEE 802.3：乙太網路（Ethernet）
IEEE 802.4：權杖匯流排（Token bus）
IEEE 802.5：權杖環（Token-Ring）
IEEE 802.6：城域網（MAN, Metropolitan Area Network）
IEEE 802.7：寬頻TAG（Broadband LAN using Coaxial Cable）
IEEE 802.8：光纖分散式資料介面（FDDI）
IEEE 802.9：綜合業務區域網路（Integrated Services LAN）
IEEE 802.10：區域網路網路安全（Interoperable LAN Security）
IEEE 802.11：無線區域網路（Wireless LAN & Mesh）
IEEE 802.12：需求優先級（Demand priority）
IEEE 802.13：（未使用）
IEEE 802.14：電纜數據機（Cable modems）
IEEE 802.15：無線個人區域網路（Wireless PAN）
IEEE 802.15.1：無線個人區域網路絡（WPAN, Wireless Personal Area Network）
IEEE 802.15.4：低速無線個人區域網路絡（LR-WPAN, Low Rate Wireless Personal Area Network）
IEEE 802.16：寬頻無線接入（Broadband Wireless Access）
IEEE 802.17：彈性封包環傳輸技術（Resilient packet ring）
IEEE 802.18：無線電管制技術（Radio Regulatory TAG）
IEEE 802.19：共存標籤（Coexistence TAG）
IEEE 802.20：移動寬頻無線接入（Mobile Broadband Wireless Access）
IEEE 802.21：媒介獨立換手（Media Independent Handover）
IEEE 802.22：無線區域網（Wireless Regional Area Network）
IEEE 802.23：緊急服務工作群組（Emergency Services Working Group），2010年3月新發布
```
# 網路協定:

#### OSI 
```
應用層 Application 

表達層 Presentation

會議層 Session 

傳輸層

OSI Model Explained | OSI Animation | Open System Interconnection Model | OSI 7 layers | TechTerms
https://www.youtube.com/watch?v=vv4y_uOneC0
```
### ARP
```
Address Resolution Protocol (ARP) - Explained with example | Computer network | TechTerms
https://www.youtube.com/watch?v=EC1slXCT3bg

MAC Address
```
### ICMP
```
Internet Control Message Protocol

● ICMP 在溝通之中，主要是透過不同的類別( Type )與代碼( Code ) 讓機器來識別不同的連線狀況。常用的類別如下表所列﹕

類別	名稱	代表意思
0	Echo Reply	是一個回應信息。
3	Distination Unreachable	表示目的地不可到達。
4	Source Quench	當 router 負載過時﹐用來竭止來源繼續發送訊息。
5	Redirect	用來重新導向路由路徑。
8	Echo Request	請求回應訊息。
11	Time Exeeded for a Datagram	當資料封包在某些路由現象中逾時﹐告知來源該封包已被忽略忽略。
12	Parameter Problem on a Datagram	當一個 ICMP 封包重複著之前的錯誤時﹐會回覆來源主機關於參數錯誤的訊息。
13	Timestamp Request	要求對方送出時間訊息﹐用以計算路由時間的差異﹐以滿足同步性協定的要求。
14	Timestamp Replay	此訊息純粹是回應 Timestamp Request 用的。
15	Information Request	在 RARP 協定應用之前﹐此訊息是用來在開機時取得網路信息。
16	Information Reply	用以回應 Infromation Request 訊息。
17	Address Mask Request	這訊息是用來查詢子網路 mask 設定信息。
18	Address Mask Reply	回應子網路 mask 查詢訊息的。

● 在 ICMP 使用中﹐不同的類別會以不同的代碼來描述具體的狀況。以 Type 3 ( Distination Unreachable ) 為例，其下的代碼如下所列﹕

代碼	代表意思
0: Network Unreachable（無法到達目的網路）

1: Host Unreachable（無法到達目的主機）

2: Protocol Unreachable（通訊協定不存在）

3: Port Unreachable（無法到達連接埠）

4: Fragmentation Needed and DF set（資料需分割並設定不可分割位元）

5: Source Route Failed（來源路徑選擇失敗）

6: Destination Network Unknown（無法識別目的地網路）

7: Destination Host Unknown（無法識別目的地主機）

8: Source Host Isolated（來源主機被隔離）

9: Communication with Destination Network Administratively Prohibited（管理上禁止和目的地網路通訊）

10: Communication with Destination Host Administratively Prohibited（管理上禁止和目的地主機通訊）

11: Network Unreachable for Type of Service（無法到達此型態的網路服務）

12: Host Unreachable for Type of Service（無法到達此型態的主機服務）
ICMP 是個非常有用的協定﹐尤其是當我們要對網路連接狀況進行判斷的時候。下面讓我們看看常用的 ICMP 實例，以更好了解 ICMP 的功能與作用。

```
#### ICMP Message Format封包格式:

![ICMP 封包格式](icmp_header.gif)
```
ICMP 封包格式，其各欄位功能如下：
● 訊息型態（Message Type）：表示該 ICMP 所欲控制之訊息型態，共有 13 種型態，訊息型態之型態代表值如表 5-2 所示。
● 編碼（Code）：對各種訊息型態進一步說明工作內容。
● 檢查集檢查碼（Checksum）：對該封包檢查集錯誤偵測。
● 訊息說明（Message description）：依照不同的控制訊息，而有不同的說明方式。
```
#### Message Type
```
ICMP 訊息功能

[重要]0  Echo Reply（回應答覆）
[重要]3  Destination Unreachable（目的地無法到達）

4 Source Quench（來源抑制）

[重要]5 Redirect（改變傳輸路徑）

[重要]8 Echo Request（回應要求）

9 Router Advertisement（路由器宣傳）
10 Router Solicitation（路由器懇請）
11 Time Exceeded for a Datagram（溢時傳輸）
12 Parameter Problem on a Datagram（參數問題）
13 Timestamp Request（時間標籤要求）
14 Timestamp Reply（時間標籤回覆）
15 Information Request（資訊要求）（停用）
16 Information Reply（資訊回覆）（停用）
17 Address Mask Request（位址遮罩要求）
18 Address Mask Reply（位址遮罩回覆）
```

```
ping 
tracert| Traceroute
(Windows tracert / Linux run)
如何使用 TRACERT 疑難排解 Windows 中的 TCP/IP 問題
https://support.microsoft.com/zh-tw/help/314868/how-to-use-tracert-to-troubleshoot-tcp-ip-problems-in-windows
```
```
tracert www.pchome.com.tw

在上限 30 個躍點上
追蹤 www.pchome.com.tw [210.59.230.39] 的路由:

  1     3 ms    <1 ms     4 ms  172.20.155.254
  2    <1 ms    <1 ms    <1 ms  172.16.190.253
  3    13 ms    <1 ms    <1 ms  120-114-151-14.ksu.edu.tw [120.114.151.14]
  4     *        *        *     要求等候逾時。
  5     *        *        *     要求等候逾時。
  6     *        *        *     要求等候逾時。
  7     *        *        *     要求等候逾時。
  8     *        *        *     要求等候逾時。
  9     *        *        *     要求等候逾時。
 10     *        *        *     要求等候逾時。
```
```
在上限 30 個躍點上
追蹤 www.ksu.edu.tw [120.114.100.65] 的路由:

  1    <1 ms    <1 ms    <1 ms  172.20.155.254
  2    <1 ms    <1 ms    <1 ms  120-114-50-230.ksu.edu.tw [120.114.50.230]
  3    <1 ms    <1 ms    <1 ms  chs.www.ksu.edu.tw [120.114.100.65]

追蹤完成。
```
#### tracert ksu 
```
![tracert ksu](https://github.com/ChengHan16/Cs4high_4080E036/tree/master/Network)
```
### TCP vs UDP 
```
TCP vs UDP Comparison
https://www.youtube.com/watch?v=uwoD5YsGACg
```


### SSL, TLS, HTTP, HTTPS 
```
SSL, TLS, HTTP, HTTPS Explained
https://www.youtube.com/watch?v=hExRDVZHhig
```

###  Proxy Server
```
What is a Proxy Server?
https://www.youtube.com/watch?v=5cPIukqXe5w
```

### FTP (File Transfer Protocol), SFTP, TFTP Explained.
```
FTP (File Transfer Protocol), SFTP, TFTP Explained.
https://www.youtube.com/watch?v=tOj8MSEIbfA
```
# RFID
```
無線射頻辨識（英語：Radio Frequency IDentification，縮寫：RFID）是一種無線通訊技術，可以通過無線電訊號識別特定目標並讀寫相關數據，而無需識別系統與特定目標之間建立機械或者光學接觸。
```
# TCP
```
● 可靠性 : 能夠確保資料完整的傳輸，確認是否有接收到，封包格式確認，回傳確認(三項交握)
● 不可靠性 : 傳輸過去的資料不管有沒有正確都不會再次確認、回傳(很小的影響或可接性)
```
#### TCP Format
```
![TCP Format](TCP_Format.png)
```
# 不可靠的unreliable UDP
```
不可靠的unreliable UDP
https://en.wikipedia.org/wiki/User_Datagram_Protocol


許多關鍵的網際網路應用程式使用UDP，包括：
域名系統（DNS），其中查詢階段必須快速，並且只包含單個請求，後跟單個回覆封包；
動態主機組態協定（DHCP），用於動態分配IP位址；
簡單網路管理協定（SNMP）；
路由資訊協定（RIP）。

● UDP構建可靠資料傳輸
  簡單來講，要使用UDP來構建可靠的面向連線的資料傳輸，就要實現類似於TCP協議的超時重傳，有序接受，應答確認，滑動視窗流量控制等機制，等於說要在傳輸層的   上一層（或者直接在應用層）實現TCP協議的可靠資料傳輸機制，比如使用UDP資料包+序列號，UDP資料包+時間戳等方法，在伺服器端進行應答確認機制，這樣就會保證   不可靠的UDP協議進行可靠的資料傳輸。

● UDT（UDP-based Data Transfer Protocol）
  基於UDP的資料傳輸協議（UDP-based Data Transfer Protocol，簡稱UDT）是一種網際網路資料傳輸協議。UDT的主要目的是支援高速廣域網上的海量資料傳輸，而   網際網路上的標準資料傳輸協議TCP在高頻寬長距離網路上效能很差。 顧名思義，UDT建於UDP之上，並引入新的擁塞控制和資料可靠性控制機制。UDT是面向連線的雙向   的應用層協議。它同時支援可靠的資料流傳輸和部分可靠的資料報傳輸。 由於UDT完全在UDP上實現，它也可以應用在除了高速資料傳輸之外的其它應用領域，例如點到   點技術（P2P），防火牆穿透，多媒體資料傳輸等等。
  UDT是雙工的，每個UDT實體有兩個部分：傳送和接收。傳送者根據流量控制和速率控制來發送（和重傳）應用程式資料。接收者接收資料包和控制包，並根據接收到的   包傳送控制包。傳送和接收程式共享同一個UDP埠來發送和接收。
```
```
UDP Format
UDP報頭包括4個欄位，每個欄位占用2個位元組（即16個位元）。
在IPv4中，「來源連接埠」和「校驗和」是可選欄位（以粉色背景標出）。
在IPv6中，只有來源連接埠是可選欄位。 
各16bit的來源埠和目的埠用來標記傳送和接受的應用行程。

UDP不需要應答，所以來源埠是可選的，如果來源埠不用，那麼置為零。
在目的埠後面是長度固定的以位元組為單位的長度域，用來指定UDP資料報包括資料部分的長度，長度最小值為8byte。
首部剩下地16bit是用來對首部和資料部分一起做校驗和（Checksum）的，這部分是可選的，
但在實際應用中一般都使用這一功能。

[3]報文長度
該欄位指定UDP報頭和資料總共占用的長度。
可能的最小長度是8位元組，因為UDP報頭已經占用了8位元組。
由於這個欄位的存在，UDP報文總長不可能超過65535位元組（包括8位元組的報頭，和65527位元組的資料）。
實際上通過IPv4協定傳輸時，由於IPv4的頭部資訊要占用20位元組，因此資料長度不可能超過65507位元組
               （65,535 − 8位元組UDP報頭 − 20位元組IP頭部）。
在IPv6的jumbogram中，是有可能傳輸超過65535位元組的UDP封包的。
依據RFC 2675，如果這種情況發生，報文長度應被填寫為0。


[4]校驗和checksum
校驗和欄位可以用於發現頭部資訊和資料中的傳輸錯誤。
該欄位在IPv4中是可選的，在IPv6中則是強制的。
如果不使用校驗和，該欄位應被填充為全0。
```
### DNS
```

```

### DNS
```

```

### DNS
```

```
#### ARP
```
C:\Users\KSUIE>ARP -a

介面: 192.168.57.1 --- 0x4
  網際網路網址          實體位址               類型
  192.168.57.255        ff-ff-ff-ff-ff-ff     靜態
  224.0.0.3             01-00-5e-00-00-03     靜態
  224.0.0.22            01-00-5e-00-00-16     靜態
  224.0.0.251           01-00-5e-00-00-fb     靜態
  224.0.0.252           01-00-5e-00-00-fc     靜態
  239.255.255.250       01-00-5e-7f-ff-fa     靜態

介面: 172.20.155.232 --- 0x6
  網際網路網址          實體位址               類型
  172.20.155.16         88-d7-f6-53-83-c0     動態
  172.20.155.22         88-d7-f6-53-24-ac     動態
  172.20.155.38         88-d7-f6-53-24-9b     動態
  172.20.155.50         88-d7-f6-53-82-e5     動態
  172.20.155.51         88-d7-f6-53-85-b8     動態
  172.20.155.56         38-2c-4a-c6-c6-29     動態
  172.20.155.61         88-d7-f6-53-84-19     動態
  172.20.155.97         88-d7-f6-53-83-4a     動態
  172.20.155.100        88-d7-f6-53-83-98     動態
  172.20.155.102        70-4d-7b-a3-4c-d4     動態
  172.20.155.126        88-d7-f6-53-83-f7     動態
  172.20.155.145        88-d7-f6-53-24-2b     動態
  172.20.155.153        88-d7-f6-53-24-87     動態
  172.20.155.157        70-4d-7b-a3-4d-68     動態
  172.20.155.177        70-4d-7b-a3-4d-b6     動態
  172.20.155.178        38-2c-4a-c6-c2-e6     動態
  172.20.155.181        88-d7-f6-53-25-25     動態
  172.20.155.201        88-d7-f6-53-85-d5     動態
  172.20.155.216        88-d7-f6-53-83-0d     動態
  172.20.155.230        88-d7-f6-53-85-c3     動態
  172.20.155.231        88-d7-f6-53-85-a5     動態
  172.20.155.254        00-14-1b-72-a8-00     動態
  172.20.155.255        ff-ff-ff-ff-ff-ff     靜態
  224.0.0.3             01-00-5e-00-00-03     靜態
  224.0.0.22            01-00-5e-00-00-16     靜態
  224.0.0.251           01-00-5e-00-00-fb     靜態
  224.0.0.252           01-00-5e-00-00-fc     靜態
  239.255.64.75         01-00-5e-7f-40-4b     靜態
  239.255.255.250       01-00-5e-7f-ff-fa     靜態
  255.255.255.255       ff-ff-ff-ff-ff-ff     靜態

介面: 192.168.173.2 --- 0xc
  網際網路網址          實體位址               類型
  192.168.173.255       ff-ff-ff-ff-ff-ff     靜態
  224.0.0.3             01-00-5e-00-00-03     靜態
  224.0.0.22            01-00-5e-00-00-16     靜態
  224.0.0.251           01-00-5e-00-00-fb     靜態
  224.0.0.252           01-00-5e-00-00-fc     靜態
  239.255.255.250       01-00-5e-7f-ff-fa     靜態
```
```
![ARP](ARP.PNG)

