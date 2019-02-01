
import Foundation

class MyData: Codable {
    
}

/**
 Used to alert viewControllers when data has been changed.
 */
protocol DatasetDelegate: class {
    func datasetUpdated()
}

/**
 Stores the state of the dataset.
 This is a good place to add anything that needs to be stored.
 */
struct DataPersist: Codable {
    let data: [MyData]
}

/**
 Provides data storage and operations on stored data.
 */
class Dataset {
    
    private static var data: [MyData] = []
    
    private static weak var delegate: DatasetDelegate?
    
    /**
     Returns the number of entries in the dataset.
     */
    static var count: Int {
        return data.count
    }
    
    /**
     Returns the entry at the given index if it exists.
     */
    static func data(atIndex index: Int) -> MyData? {
        return data[index]
    }
    
    /**
     Adds an entry to the dataset.
     */
    static func add(_ entry: MyData) {
        data.append(entry)
        delegate?.datasetUpdated()
    }
    
    /**
     Replaces the entry at the given index in the dataset.
     */
    static func replaceEntry(atIndex idx: Int, with entry: MyData){
        data[idx] = entry
        delegate?.datasetUpdated()
    }
    
    /**
     Removes the entry at the given index.
     */
    static func remove(atIndex idx: Int){
        data.remove(at: idx)
        delegate?.datasetUpdated()
    }
    
    /**
     Registers a delegate to listen to changed events.
     */
    static func registerDelegate(_ delegate: DatasetDelegate){
        self.delegate = delegate
    }
    
    /************************ Persistance functions ***********************/
    //Saves everything in the dataset to a JSON file.
    static func saveData() -> Data {
        let encoder = JSONEncoder()
        let persistance = DataPersist(data: self.data)
        do {
            return try encoder.encode(persistance)
        }
        catch {
            //Bad things?
            return Data()
        }
    }
    
    /**
     Restores all the data from JSON.
     */
    static func restoreData(from _data: Data) {
        let persistance: DataPersist
        let decoder = JSONDecoder()
        do {
            persistance = try decoder.decode(DataPersist.self, from: _data)
            data = persistance.data
        }
        catch {
            data = []
        }
        
        delegate?.datasetUpdated()
    }
}
