# Scanner、Get、Set
```
package online;

public class Customer {
    
    //屬性
    private static int numofCustomers;
    private String customerID;
    private String customerID_series = "c0002020-";
    
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
    
    public void printCustomerInfo() {
        System.out.println(
        customerID + "\t" +
        name + "\t" +
        address + "\t" +
        phone_number + "\t" +
        email_address);
    }
    
    //getter(s) and setter(s) 副函式
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
        //Customer[] customer_array = new Customer[6];
        ArrayList<Customer> customer_List = new ArrayList<Customer>(); 
        //ArrayList<Order> order_List = new ArrayList<Order>(); 
        Scanner in = new Scanner(System.in);
        int create = 1;
        String name;
        String address;
        String email;
        String phone;
        do {
            System.out.print("Please enter customer name:");
            name = in.nextLine();
            System.out.print("Please enter customer address:");
            address = in.nextLine();
            System.out.print("Please enter customer phone number:");
            phone = in.nextLine();
            System.out.print("Please enter customer email:");
            email = in.nextLine();
            
            customer_List.add(
                    new Customer(name, address, phone, email));
            
            System.out.print("Continue to create Customer? 1: yes / -1: no");
            create = in.nextInt();
            
        }while(create!=-1);
        
        System.out.println(Customer.getNumofCustomers());
        
        for(int i = 0; i < customer_List.size() ;  i++) {
            customer_List.get(i).printCustomerInfo();
        }
        
        for(int i = 0; i < customer_List.size()  ;  i++) {
            System.out.println(customer_List.get(i).getName());
        }
        
        for(int i = 0; i < customer_List.size() ;  i++) {
            System.out.println(customer_List.get(i).getEmail_address());
        }     
    }
}
```


