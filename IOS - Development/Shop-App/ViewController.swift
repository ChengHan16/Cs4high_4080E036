
import UIKit

class ViewController: UIViewController, UITableViewDataSource, UITableViewDelegate{
	@IBOutlet weak var tableView: UITableView!
	
	var balls: Array<Dictionary<String, String›> = [Dictionary‹String, String>]()
	
	var names: Array<String> = [String] ()
	var values: Array‹String> = [String]()
	var imageNames: Array‹String> = [String] ()
	var contents:Array‹String> = [String]()

	// aryCheck records the status of the checkbox
	var arrayCheck = [Bool]() //[false, false, false, falsel

	override func viewDidLoad()
		super.viewDidLoad()
		
		self.names = ["basketbalt","footballM","baseball", "other", "cricket ball", "golf ball", "snooker ball", "solid steel ball", "spiky ball","tennis ball","XFL football"]
		self. values = ["S100","$200","$300","$400","500","$600","$700","$800","$900","$1000","$1100"]
		self.imageNames = ["basketball","football","baseball","other","cricketball","golfball","snookerball","solid steelball","spikyball","tennisball","XFL_football"]

		// put ball's contents together in terms of dictionary data type
		for item in 0..<self.names.count {
			let content = loadString(self.imageNames[item])
			let dic = ["name": self.namesliteml,"value": self.values[item], "imageName": self.imageNames[item], "content": content]
			self.balls.append (dic)
		｝
		self.arrayCheck = [Bool](repeating: false, count: self.balls.count)
		//arrayCheck = [false,false, false, false]
	}
	
	// process the App when clicping on the cell by implementing the method: didSelectRowAtIndexPath
	func tableView(_ tableView: UITableView, didSelectRoWAt indexPath: IndexPath){
		// access the current cell by implementing tableView.cellForRowAtIndexPath
		let cell:UITableViewCell = (tableView.cellForRow(at: indexPath) as UITableViewCell?)!
		// change the status of the checkbox
		arrayChecklindexPath.row] = !arrayChecklindexPath.row]
		//setup the indicator according the status of checkbox
		if arrayCheck[indexPath.row]{
			cell-accessoryType=UITableViewCell.AccessoryType.checkmark
		} else {
			cell.accessoryType = UITableViewCell.AccessoryType.none
		}
	}
	// share
	func tableView(_ tableView: UITableView, editActionsForRowAt indexPath: IndexPath) -> [UITableViewRowAction]? {
	//share action
		let shareAction = UITableViewRoWAction(style: .default, title: "Share", handler: {(action, indexPath) -> Void in
			let ball = self.balls[indexPath.row]
			let defaultText = "Share" + balll"name"]!
		
			if let imageToShare = UIImage(named: ball["imageName"]!){
				let activityControl = UIActivityViewController(activityItems: [defaultText, imageToShare], applicationActivities: nil)
				self. present (activityControl, animated: true, completion: nil)
			}
		})
		
		// delete action
		let deleteAction = UITableViewRowAction(style: .default, title: "Delete", handler: ((action, indexPath) -> Void in
			self.arrayCheck.remove(at: indexPath.row)
			self.balls.remove (at: indexPath.row)
			tableView.deleteRows (at: [indexPathl, with: . fade)
		})
			
		shareAction.backgroundColor = UIColor(red:48.0/255.0,green:173.0/255.0,blue:99.0/255.0,alpha:1.0)



		// delete action
		let deleteAction = UITableViewRowAction(style: .default, title: "Delete", handler: ((action, indexPath) -> Void in
			self.arrayCheck.remove(at: indexPath.row)
			self.balls.remove(at: indexPath.row)
			tableView.deleteRows (at: [indexPath], with: .fade)
		})
		
		shareAction.backgroundColor = UIColor(red: 48.0/255.0, green: 173.0/255.0, blue: 99.0/255.0, alpha: 1.0)
		deleteAction.backgroundColor = UIColor(red: 202.0/255.0, green: 202.0/255.0, blue: 203.0/255.0, alpha: 1.0)
		
		tableView.reloadData()
		
		return [deleteAction, shareAction]
	}
	
	//access the number of row within the table by implementing the method: numberOfRowsInSection
	func tableView(_ tableView: UITableView, numberOfRowsInSection section: Int) ->Inti{
		return self.balls. count
	}
	// display content of each cell on the tableView by implementing the method: cellForRowAtIndexPath
	func tableView(_ tableView: UITableView, cellForRowAt indexPath: IndexPath) -> UITableViewCell{
		// setupcontent ofleachcen1 using the method: tableView. dequeueReusablecel1WithIdentifier to access the identifiem： cel1
		let cellIdentifier = "Cell"
		guard let cell = tableView.dequeueReusableCell(withIdentifier:cellIdentifier,for:indexPath)as? BallTableViewcell else{
			fatalError ("The dequeued cell is not an instance of BallTableViewCell.")
		}
		
		// Configure the cell
		let ball: Dictionary‹String, String> = self.balls[indexPath.row]
		cell.nameLabel?.text = ball|*name"] // name
		cell.valueLabel?. text - ballInvalue"] // price
		let image = getPhotoFromFile(ball["imageName"]!)
		cell.ballImage?.image = image
		
		return cell
	}
