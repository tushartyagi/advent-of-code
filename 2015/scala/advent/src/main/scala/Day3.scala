package advent

import scala.io.Source

object Day3 {
  type Move = (Int, Int)

  def move(c: Char, pos: Move): Move = c match {
    case '>' => (pos._1 + 1, pos._2)
    case '<' => (pos._1 - 1, pos._2)
    case '^' => (pos._1, pos._2 - 1)
    case 'v' => (pos._1, pos._2 + 1)
    case _ => throw new Exception("Invalid move")
  }

  def moves(s: List[Char]): List[Move] = {
    if (s.isEmpty) List()
    else move(s.head, (0,0)) :: moves(s.tail)
  }

  // Need to find the tail-recursive version of this.
  def iterativeMovement(s: List[Char]): Int = {
    var pos = (0, 0)
    var uniquePositions = Set[Move](pos)
    for (c <- s) {
      pos = move(c, pos)
      uniquePositions += pos
    }
    uniquePositions.size
  }

  def tailRecursiveMovement(s: List[Char]): Int = {
    val init = (0,0)

    def helper(pos: Move, s: Set[Move], moves: List[Char]): Int = moves match {
      case Nil => s.size
      case (x::xs) => {
        val newPos = move(x, pos)
        helper(newPos, s + newPos, xs)
      }
    }

    helper(init, Set[Move](init), s)
  }

  def uniqueHouseCount(s: List[Char]): Int = tailRecursiveMovement(s)
  
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
