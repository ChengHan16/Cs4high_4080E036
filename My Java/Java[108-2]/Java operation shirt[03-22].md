# Shirt
```
package online;

public class Shirt {
	    private static int numofShirt;
	    private String shirtID;
	    private String shirtID_series = "shirt";
	    //private int shirtID_index;
	    private String price;
	    private String description;
	    private String size;
	    private String colorcode;
	    
	    public Shirt() {
	        this.shirtID = assignShirtID();
	    }
	    
	    public Shirt(String shirtID, String price,String description, String size,String colorcode) {
	        this.shirtID = assignShirtID();
	        this.price = price;
	        this.description = description;
	        this.size = size;
	        this.colorcode = colorcode;
	        
	    }
	    
	    public String assignShirtID() {
	        Shirt.setNumofShirts((Shirt.getNumofShirts()+1));
	        String id = shirtID_series + (Shirt.getNumofShirts());
	        
	        return id;
	    }
	    
	    public void printShirtInfo() {
	        System.out.println(shirtID + " " +price + " " +description + " " +size + " " +colorcode);
	    }
	    
	    public static int getNumofShirts() {
	        return numofShirt;
	    }

	    public static void setNumofShirts(int numofShirts) {
	        Shirt.numofShirt = numofShirts;
	    }

}
```
# Test_shirt
```
package online;

public class Test_shirt {
	public static void main(String[] args) {
        Shirt.setNumofShirts(0);
        
        Shirt[] shirt_array = new Shirt[6];
        shirt_array[0] = new Shirt("001","99$","描述","Blue",null);
        shirt_array[1] = new Shirt();
        shirt_array[2] = new Shirt();
        shirt_array[3] = new Shirt();
        shirt_array[4] = new Shirt();
        shirt_array[5] = new Shirt();
        System.out.println(Shirt.getNumofShirts());
        
        for(int i = 0; i < shirt_array.length ;  i++) {
        	shirt_array[i].printShirtInfo();
        	}
    	}
}
```
# 輸出結果
```
6
shirt1 99$ 描述 Blue null
shirt2 null null null null
shirt3 null null null null
shirt4 null null null null
shirt5 null null null null
shirt6 null null null null
```
