# Payment
```
package online;

public class Payment {
	    private static int numofPayments;
	    private String paymentID;
	    private String paymentID_series = "customer";
	    //private int paymentID_index;
	    private String name;
	    private String address;
	    private String phone_number;
	    private String email_address;
	    private String order;
	    
	    public Payment() {
	        this.paymentID = assignPaymentID();
	    }
	    
	    public Payment(String paymentID, String name,String address, String phone_number,String email_address,String order) {
	        this.paymentID = assignPaymentID();
	        this.name = name;
	        this.address = address;
	        this.phone_number = phone_number;
	        this.email_address = email_address;
	        this.order = order;
	    }
	    
	    public String assignPaymentID() {
	        Payment.setNumofPayments((Payment.getNumofPayments()+1));
	        String id = paymentID_series + (Payment.getNumofPayments());
	        
	        return id;
	    }
	    
	    public void printPaymentInfo() {
	        System.out.println(paymentID + " " +name + " " +address + " " +phone_number + " " +email_address+ " " + order);
	    }
	    
	    public static int getNumofPayments() {
	        return numofPayments;
	    }

	    public static void setNumofPayments(int numofPayments) {
	        Payment.numofPayments = numofPayments;
	    }

}
```
# Test_payment
```
package online;

public class Test_Payment {
	 public static void main(String[] args) {
	        Payment.setNumofPayments(0);
	        
	        Payment[] payment_array = new Payment[6];
	        payment_array[0] = new Payment("Cheng Han Wu","台南市崑大路1號","0900-123456","s108000111@ksu.edu.tw","111",null);
	        payment_array[1] = new Payment();
	        payment_array[2] = new Payment();
	        payment_array[3] = new Payment();
	        payment_array[4] = new Payment();
	        payment_array[5] = new Payment();
	        System.out.println(Payment.getNumofPayments());
	        
	        for(int i = 0; i < payment_array.length ;  i++) {
	        	payment_array[i].printPaymentInfo();
	        	}
	    	}
}
```
# 輸出結果
```
6
customer1 台南市崑大路1號 0900-123456 s108000111@ksu.edu.tw 111 null
customer2 null null null null null
customer3 null null null null null
customer4 null null null null null
customer5 null null null null null
customer6 null null null null null
```
