package advent

import scala.io.Source

object Day1 {
  def CountFloors(s: String): Int = {
    if (s.isEmpty())
      0
    else if (s.startsWith("(")) {
      CountFloors(s.substring(1)) + 1
    }
    else if (s.startsWith(")")) {
      CountFloors(s.substring(1)) - 1
    }
    else {
      throw new Exception("Invalid argument")
    }
  }

  private def accumulator(r: Int, c: Char): Int = {
    0
  }

  private def helper(floor: Int, pos: Int, s: String): Int = {
    if (floor == -1) pos
    else if (s.startsWith("(")) helper(floor + 1, pos + 1, s.substring(1))
    else if (s.startsWith(")")) helper(floor - 1, pos + 1, s.substring(1)) 
    else {
      throw new Exception("Invalid argument")
    }   
  }

  def EnterBasement(s: String): Int = {
    helper(0,0,s)
  }

  def run() {
    val stream = getClass.getResourceAsStream("/day1.txt")
    val source = Source.fromInputStream(stream)
    val parens: String = try source.mkString.trim finally source.close()
    val floors = Day1.CountFloors(parens)
    val position = Day1.EnterBasement(parens)
    println("Floors: " + floors) // 138
    println("Position of hitting basement: " + position) // 1771 (Quite big!)
  }
}


