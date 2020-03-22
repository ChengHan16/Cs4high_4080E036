# Custome
```
package online;

public class Customer {
    private static int numofCustomers;
    private String customerID;
    private String customerID_series = "customer";
    //private int customerID_index;
    private String name;
    private String address;
    private String phone_number;
    private String email_address;
    
    public Customer() {
        this.customerID = assignCustomerID();
    }
    
    public Customer(String customerID, String name,String address, String phone_number,String email_address) {
        this.customerID = assignCustomerID();
        this.name = name;
        this.address = address;
        this.phone_number = phone_number;
        this.email_address = email_address;
        
    }
    
    public String assignCustomerID() {
        Customer.setNumofCustomers((Customer.getNumofCustomers()+1));
        String id = customerID_series + (Customer.getNumofCustomers());
        
        return id;
    }
    
    public void printCustomerInfo() {
        System.out.println(customerID + " " +name + " " +address + " " +phone_number + " " +email_address);
    }
    
    public static int getNumofCustomers() {
        return numofCustomers;
    }

    public static void setNumofCustomers(int numofCustomers) {
        Customer.numofCustomers = numofCustomers;
    }

}
```
# Test_customer
```
package online;

public class Test_customer {

    public static void main(String[] args) {
        Customer.setNumofCustomers(0);
        
        Customer[] customer_array = new Customer[6];
        customer_array[0] = new Customer("Cheng Han Wu","台南市崑大路1號","0900-123456","s108000111@ksu.edu.tw",null);
        customer_array[1] = new Customer("Le Cheng Der","台南市崑大路2號","0900-456789","s108000222@ksu.edu.tw",null);
        customer_array[2] = new Customer("Wen Go Yun","台南市崑大路3號","0900-789456","s108000333@ksu.edu.tw",null);
        customer_array[3] = new Customer("Yu Go Han","台南市崑大路4號","0900-456123","s108000444@ksu.edu.tw",null);
        customer_array[4] = new Customer("Yu Gi Ho","台南市崑大路5號","0900-741852","s108000555@ksu.edu.tw",null);
        customer_array[5] = new Customer("Ter Jer Yer","台南市崑大路6號","0900-852963","s108000666@ksu.edu.tw",null);
        System.out.println(Customer.getNumofCustomers());
        
        for(int i = 0; i < customer_array.length ;  i++) {
        	customer_array[i].printCustomerInfo();
        	}
    	}
    }
```
# 輸出結果
```
6
customer1 台南市崑大路1號 0900-123456 s108000111@ksu.edu.tw null
customer2 台南市崑大路2號 0900-456789 s108000222@ksu.edu.tw null
customer3 台南市崑大路3號 0900-789456 s108000333@ksu.edu.tw null
customer4 台南市崑大路4號 0900-456123 s108000444@ksu.edu.tw null
customer5 台南市崑大路5號 0900-741852 s108000555@ksu.edu.tw null
customer6 台南市崑大路6號 0900-852963 s108000666@ksu.edu.tw null
```

