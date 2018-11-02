package advent

import org.scalatest.FunSpec
import Day2._


class Day2Spec extends FunSpec {
  describe("parseSides correctly handles Input") {
    it("should return 0 for empty string"){
      val sides = parseSides("3x4x5")
      assert(sides.length == 3)
      assert(sides.sameElements(Array(3,4,5)))
    }
  }

  describe("smallestTwo"){
    it("should return the smallest two of the three numbers") {
      val firstCheck = smallestTwo(List(1,2,3))
      assert(firstCheck.sameElements(List(1,2)))
    }
  }
  describe("surfaceArea"){
    it("should calculated the area correctly") {
      val firstCheck = surfaceArea(List(2,3,4))
      assert(firstCheck == 52)
    }
  }
  describe("totalPaper") {
    it("should correctly find the total paper required") {
      val paper = totalPaper(List(2,3,4))
      assert(paper == 58)
    }
  }

  describe("parseAndGetPaper") {
    it("should correctly find the total paper required") {
      val paper = parseAndGetPaper("2x3x4")
      assert(paper == 58)
    }
  }
  describe("Ribbon calculation") {
    it("should correctly find the total ribbon required") {
      val ribbon = parseAndGetRibbon("2x3x4")
      assert(ribbon == 34)
    }
  }

}
