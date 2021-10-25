//
//DetailViewController.swift
//TableViewig10701
//Created by jason Tseng on 2018/10/24.
//Copyright © 2018# jason Tseng. All rights reserved
//TableView10701 | Build TableView10701: Succeeded | 2020/12/23 at 3:52 PM

import UIKit

class DetailViewController:UIViewController
  @IBOutlet weak var ballImage: UlImageView!

  @IBOutlet weak var name: UILabel!

  @IBOutlet weak var value: UILabel!

  @IBOutlet weak Var textLabel: UILabel!

  var ball = [String:String]()
  //var content = String()

  override func viewDidload() {
       super .viewDidload()
       let image = getPhotoFromFile(ball["imageName"]!)
       ballImage.image = image
       name.text = ball[*name"]
       value.text = ball/ value!]
       textLabel.text = ballf"content"]

       // Do any additional setup after loading the view.
  }
  override func didReceiveMemorywarning()
       super didReceiveMemorywarning()
       // Dispose of any resources that can be recreated.
  }

  @IBOutlet weaK var value: UILabel!

  @IBOutlet weak var textLabel: UILabel!

  var ball = [String: String]()
  //var content = String()

  override func viewDidLoad(){
      super.viewDidLoad()
      let image = getPhotoFromFile(ball["imageName"]!)
      ballImage.image = image
      name.text = ball["name"]
      value.text = ball0 value"]
      textlabel.text = ball[ content]

      // Do an additional setup after loading the view.
  }  

  override func didReceiveMemoryWarning(){
      super.didReceiveMemorywarning()
      // Dispose of any resources that can be recreated.
  }

/*
    // MARK: - Navigation

    // In a storyboard-based application, you will often want to do a little preparation before navigation
    override func prepare (for segue: UTStoryboardSegue, sender: Any?){
        // Get the new view controller using segue destinationViewController
        //Pass the selected object to the new view controller
    }
*/

}
