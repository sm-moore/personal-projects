//Created by Sara Adamson

import UIKit

/**
 Displays all the users existing alarms.
 */
class ListViewController: UITableViewController, DatasetDelegate {
    private static let cellReuseIdentifier = "ListViewController.DatasetItemsCellIdentifier"

    /**
     Setup all of the delegation for the view along with some navigation data.
     */
    override func viewDidLoad() {
        super.viewDidLoad()

        Dataset.registerDelegate(self)
        tableView.register(TableViewCell.self, forCellReuseIdentifier: AlarmListViewController.cellReuseIdentifier)

        view.backgroundColor = UIColor.white
        self.title = "Your Title"

        //Prevents navigation bar from covering the view
        self.edgesForExtendedLayout = []
    }

    /**
     Number of rows with data in them.
     */
    override func tableView(_ tableView: UITableView, numberOfRowsInSection section: Int) -> Int {
        guard tableView === self.tableView, section == 0 else {
            return 0
        }
        return Dataset.count
    }

    /**
     Swipe to delete row.
     */
    override func tableView(_ tableView: UITableView, editActionsForRowAt indexPath: IndexPath) -> [UITableViewRowAction]? {
        let delete = UITableViewRowAction(style: .destructive, title: "delete") { (action, indexPath) in
            Dataset.remove(atIndex: indexPath.row)
        }
        return [delete]
    }

    /**
     Used when the view is scrolled to generate new cells on the screen.
     NOTE: TableViewCell is a custom cell class.
     */
    override func tableView(_ tableView: UITableView, cellForRowAt indexPath: IndexPath) -> TableViewCell{
        //recycle old cells or create a new one.
        guard tableView === self.tableView, indexPath.section == 0, indexPath.row < Dataset.count else {
            return TableViewCell()
        }

        var cell: TableViewCell = tableView.dequeueReusableCell(withIdentifier: ListViewController.cellReuseIdentifier, for: indexPath) as! TableViewCell
        if cell.detailTextLabel == nil {
            cell = TableViewCell(style: .subtitle, reuseIdentifier: ListViewController.cellReuseIdentifier)
        }
        //Get the object at that index from the dataset.
        let entry = Dataset.get(atIndex: indexPath.row)!
        
        //Redraw a cell with customContent?
        cell.updateCell(with: entry)
        
        return cell
    }

    /**
     When a row is selected, edit it in another view.
     */
    override func tableView(_ tableView: UITableView, didSelectRowAt indexPath: IndexPath) {
        guard tableView === self.tableView, indexPath.section == 0, indexPath.row < Dataset.count else {
            return
        }
        //TODO: Set-up next view.
        let view = UIView()

        // When a row is selected, go to an editing view?
        navigationController?.pushViewController(view, animated: true)
    }

    /**
     Update the cells on screen with new values, this function gets called
     when dataset calls it. Aka: when the data being displayed gets changed.
     */
    func datasetUpdated() {
        //The fact that the dataset can change while editing an alarm leaves me to believe that I should
        // include unique ID's in the Alarm object rather than storing a current index.
        (view as! UITableView).reloadData()
    }
}
