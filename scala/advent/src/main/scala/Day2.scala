package advent

import scala.io.Source

object Day2 {

  def parseSides(s: String): List[Int] = {
    val dimensions = s.split("x").toList
    if (dimensions.length != 3)
      throw new Exception("Invalid dimensions")
    else 
      dimensions.map(_.toInt)
  }

  def smallestTwo(numbers: List[Int]): List[Int] = {
    numbers.sorted.take(2)
  }

  def surfaceArea(dimensions: List[Int]) = dimensions match {
    case List(l, w, h) => 2*(l*w + w*h + l*h)
    case _ => throw new Exception("This is not the correct way to send dimensions")
  }

  def totalPaper(dimensions: List[Int]): Int = {
    val area = surfaceArea(dimensions)
    val extra = smallestTwo(dimensions).product
    area + extra
  }

  val parseAndGetPaper = totalPaper _ compose parseSides _

  val parseAndGetRibbon = totalRibbon _ compose parseSides _

  def totalRibbon(dimensions: List[Int]): Int = {
    val wrapping = smallestTwo(dimensions).sum * 2
    val bow = dimensions.product
    wrapping + bow
  }

  def run() {
    val stream = getClass.getResourceAsStream("/day2.txt")
    val source = Source.fromInputStream(stream)
    try {
      val dimensions = source.getLines.toList
      val paper = dimensions.map(parseAndGetPaper).sum
      val ribbon = dimensions.map(parseAndGetRibbon).sum
      println("Total Paper: " + paper)
      println("Total Ribbon: " + ribbon)
    }
    finally
      source.close()
  }
}

