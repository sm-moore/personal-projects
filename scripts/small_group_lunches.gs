//  Fisher-Yates Shuffle algorithm found here https://stackoverflow.com/questions/2450954/how-to-randomize-shuffle-a-javascript-array
function shuffle(array) {
  var currentIndex = array.length, temporaryValue, randomIndex;

  // While there remain elements to shuffle...
  while (0 !== currentIndex) {

    // Pick a remaining element...
    randomIndex = Math.floor(Math.random() * currentIndex);
    currentIndex -= 1;

    // And swap it with the current element.
    temporaryValue = array[currentIndex];
    array[currentIndex] = array[randomIndex];
    array[randomIndex] = temporaryValue;
  }
  return array;
}

function readValues(range, sheetIdx) {
  var ss = SpreadsheetApp.getActiveSpreadsheet();
  var sheet = ss.getSheets()[sheetIdx];
  var range = sheet.getRange(range);
  var values = range.getValues();
  return values.filter(function (el) { return el != ""});
}

function readValue(cell, sheetIdx) {
  var ss = SpreadsheetApp.getActiveSpreadsheet();
  var sheet = ss.getSheets()[sheetIdx];
  var cell = sheet.getRange(cell);
  return cell.getValue();
}

function writeValues(range, sheetIdx, values) {
  var ss = SpreadsheetApp.getActiveSpreadsheet();
  var sheet = ss.getSheets()[sheetIdx];
  var range = sheet.getRange(range);
  range.setValues(values);
}

function sum(arr) {
    result = 0
    for (i = 0; i < arr.length; i++){
        result += arr[i];
    }
    return result;
}

function reshape(groups) {
    result = [];
    for (i = 0; i < groups.length; i++) {
        for (j = 0; j < groups[i]; j++) {
            result.push([i + 1]);
        }
    }
    return result;
}

function concat(left, right){
  for(i = 0; i < right.length; i++) {
    left.push(right[i]);
  }
  return left;
}

function listOf(size, element) {
  result = [];
  for (i = 0; i < size; i++) {
    result.push(element);
  }
  return result;
}

function computeGroupNumbers(groupSize, numParticipants) {
    // The goal here is to minimize larger than groupSize groups while aiming to not have groups that are too small.
    // The optimal spread for a group of 6 would be having a maxumum of 2 groups with 7 and favor having 3 smaller groups of only 5 if there are 3 extra people. 
    groupSizes = []; // This is a list containing the size of each group, for example [5, 5, 4] means two groups with 5 people and 1 group with 4.
    if (numParticipants <= groupSize + Math.floor(groupSize / 2)) {
        groupSizes = [numParticipants];
    } else {
        extras = numParticipants % groupSize
        if (extras == 0) {
            groupSizes = listOf(Math.floor(numParticipants / groupSize), groupSize);
        } else {
            if (extras >= groupSize / 2) {
                // There will be smaller groups
                ending = listOf(groupSize - extras, groupSize - 1);
                start = listOf(Math.floor((numParticipants - sum(ending)) / groupSize), groupSize);
            } else {
                // There will be larger groups
                start = listOf(extras, groupSize + 1);
                ending = listOf(Math.floor((numParticipants - sum(start)) / groupSize), groupSize);
            }
            groupSizes = concat(start, ending);
        }
    }
    return reshape(groupSizes);
}

function randomizeGroups() {
  var ui = SpreadsheetApp.getUi();
  var button = ui.alert("Are you sure you wish to Randomize groups?", ui.ButtonSet.OK_CANCEL);
  if (button == ui.Button.OK) {
    names = readValues("A2:A", 0);
    shuffledNames = shuffle(names);
    numberOfParticipants = shuffledNames.length;
    
    lastRowNum = numberOfParticipants + 1
    writeValues("B2:B" + lastRowNum  , 0, shuffledNames);
    
    groupSize = readValue("A2", 1);
    groupNumberArray = computeGroupNumbers(groupSize, numberOfParticipants);
    writeValues("C2:C" + lastRowNum, 0, groupNumberArray);
  }
  else if (button == ui.Button.CANCEL) {}
}