# Order
```
package online;

public class Order {
	private static int numoforders;
    private String orderID;
    private String orderID_series = "order";
    //private int customerID_index;
    private String date;
    private String Shirts;
    private String totalprice;
    private String Formofpayment;
    private String CSR;
    private String status;
    
    public Order() {
        this.orderID = assignorderID();
    }
    
    public Order(String customerID, String date,String Shirts, String totalprice,String Formofpayment,String CSR,String status) {
        this.orderID = assignorderID();
        this.date = date;
        this.Shirts = Shirts;
        this.totalprice = totalprice;
        this.Formofpayment = Formofpayment;
        this.CSR = CSR;
        this.status = status;
    }
    
    public String assignorderID() {
        Order.setNumforders((Order.getNumoforders()+1));
        String id = orderID_series + (Order.getNumoforders());
        
        return id;
    }
    
    public void printOrderInfo() {
        System.out.println(orderID + " " +date + " " +Shirts + " " +totalprice + " " +Formofpayment+ " " + CSR + " " + status);
    }
    
    public static int getNumoforders() {
        return numoforders;
    }

    public static void setNumforders(int numoforders) {
        Order.numoforders = numoforders;
    }
}
```
# Test_order
```
package online;

public class Test_order {
	public static void main(String[] args) {
        Order.setNumforders(0);
        
        Order[] order_array = new Order[6];
        order_array[0] = new Order("111","1/1","100","信用卡","xxx","online",null);
        order_array[1] = new Order();
        order_array[2] = new Order();
        order_array[3] = new Order();
        order_array[4] = new Order();
        order_array[5] = new Order();
        System.out.println(Order.getNumoforders());
        
        for(int i = 0; i < order_array.length ;  i++) {
        	order_array[i].printOrderInfo();
        	}
    	}
}
```
# 輸出結果
```
6
order1 1/1 100 信用卡 xxx online null
order2 null null null null null null
order3 null null null null null null
order4 null null null null null null
order5 null null null null null null
order6 null null null null null null
```
