# Scanner、Get、Set
```
package online;

public class Customer {
	
	//屬性
    private static int numofCustomers;
    private String customerID;
    private String customerID_series = "customer";
    //private int customerID_index;
    private String name;
	private String address;
    private String phone_number;
    private String email_address;
    
    //建構子
    public Customer() {
        this.customerID = assignCustomerID();
    }
        
    public Customer(String name,
            String address, String phone_number,
            String email_address) {
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
    
    //顯示資料用(測試)
    public void printCustomerInfo() {
        System.out.println(
        customerID + "\t" +
        name + "\t" +
        address + "\t" +
        phone_number + "\t" +
        email_address);
    }
    
    //getter(s)   and   setter(s) 副函示
    public static int getNumofCustomers() {
        return numofCustomers;
    }

    public static void setNumofCustomers(int numofCustomers) {
        Customer.numofCustomers = numofCustomers;
    }
    public String getCustomerID() {
		return customerID;
	}

	public void setCustomerID(String customerID) {
		this.customerID = customerID;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public String getAddress() {
		return address;
	}

	public void setAddress(String address) {
		this.address = address;
	}

	public String getPhone_number() {
		return phone_number;
	}

	public void setPhone_number(String phone_number) {
		this.phone_number = phone_number;
	}

	public String getEmail_address() {
		return email_address;
	}

	public void setEmail_address(String email_address) {
		this.email_address = email_address;
	}
}
```
# Test
```
package online;

import java.util.ArrayList;
import java.util.Scanner;

public class Test {

    public static void main(String[] args) {
        Customer.setNumofCustomers(0);
        
        Customer[] customer_array = new Customer[6];
        ArrayList<Customer> customer_List = new ArrayList<Customer>();
        Scanner in = new Scanner(System.in);
        int create = 1;
        String name;
        String address;
        String email;
        String phone;
        do {
        	System.out.println("Please enter customer name:");
        	name = in.nextLine();
        	System.out.println("Please enter customer address:");
        	address = in.nextLine();
        	System.out.println("Please enter customer phone:");
        	phone = in.nextLine();
        	System.out.println("Please enter customer email:");
        	email = in.nextLine();
        	
        	
        	customer_array[0] = new Customer(name,address,phone ,email);
        	
        }while (create!=-1);
        	
        customer_array[0] = new Customer("Cheng Han Wu","台南市崑大路1號","0900-123456","s108000111@ksu.edu.tw");
        customer_array[1] = new Customer("Le Cheng Der","台南市崑大路2號","0900-456789","s108000222@ksu.edu.tw");
        customer_array[2] = new Customer("Wen Go Yun","台南市崑大路3號","0900-789456","s108000333@ksu.edu.tw");
        customer_array[3] = new Customer("Yu Go Han","台南市崑大路4號","0900-456123","s108000444@ksu.edu.tw");
        customer_array[4] = new Customer("Yu Gi Ho","台南市崑大路5號","0900-741852","s108000555@ksu.edu.tw");
        customer_array[5] = new Customer("Ter Jer Yer","台南市崑大路6號","0900-852963","s108000666@ksu.edu.tw");
        System.out.println(Customer.getNumofCustomers());
        
        for(int i = 0; i < customer_array.length ;  i++) {
            customer_array[i].printCustomerInfo();
        }
                
        for(int i = 0; i < customer_array.length ;  i++) {
        	System.out.println(customer_array[i].getName());
        }
                             
        for(int i = 0; i < customer_array.length ;  i++) {
        	System.out.println(customer_array[i].getEmail_address());
        }
    }
}
```


