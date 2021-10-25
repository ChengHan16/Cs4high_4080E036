//
//ProductTableViewCell.swift
//TableView10701
//Created by Apple on 2020/10/29
//Copyright © 2020 jason Tseng. All rights reserved.
//TableView10701 | Build TableView10701: Succeeded | 2020/12/23 at 3:52 PM
//

import UIKit
class BallTableViewCell: UITableViewCell {
      @IBOutlet weak var ballImage: UIImageView!
      @IBOutlet weak var namelabel: UILabel!
      @IBOutlet weak var valueLabel: UILabel!
  
      override func awakeFromNib(){
          super. awakeFromNib()
          // Initialization code
          // set a rounded thumb nail image
          setRoundedView(ballImage)
      }
  
      override func setSelected(_ selected: Bool, animated: Bool) {
          super. setSelected(selected, animated: animated)
        
          // Configure the view for the selected state
      }
  
      // rounded thumb nail image
      func setRoundedView( roundedView: UIView) {
            let saveCenter = roundedView.center
        
            // set up a new frame
            let newFrame:CGRect = CGRect (origin: CGPoint (x: roundedView.frame.origin.x, y: roundedView.frame.origin.y), size: CGSize(width:
                roundedView. frame. size.width, height: roundedView.frame.size.height))
        
            //adopt the new frame
            roundedView.layer.cornerRadius = roundedView.frame.height/2
            roundedView.frame = newFrame
            roundedView.center = saveCenter
            roundedView.clipsToBounds = true
      }
}
