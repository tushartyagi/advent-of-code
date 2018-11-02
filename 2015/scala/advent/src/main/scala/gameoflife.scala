package advent

import scala.io.Source

object Day3 {
  type Pos = (Int, Int) # row, col
  type Alive = Bool

  // Gets the valid neighbours
  def getNeighbours(pos: Pos): List[Pos] = pos match {
    var ns = List();
    case (row, col) = {
      for (r <- (row - 1).until(row + 1))
        for (c <- (col - 1).until(col + 1)) {
          if (isValid(r, c)) {
            ns.Add((r, c))
          }
        }
    }
  }

  def createWorld(world: Array): Array = {

  }

  def seed(grid: Array): Array = {
    import scala.util.Random
    val r = new Random()
    
  }

  def getGeneration(grid: Array, gen: Int): Array = {

  }
 
  def run() = {
    val stream = getClass.getResourceAsStream("/day3.txt")
    val values = Source.fromInputStream(stream)
    try {
      val listOfMoves = values.mkString.trim.toList
      val numberOfHouses = uniqueHouseCount(listOfMoves)
      println("Number of unique houses: " + numberOfHouses)
    }
    finally
      stream.close
  }
}

object Main {
  def main(args: Array[String]) = {
    Day3.run()
  }
}
