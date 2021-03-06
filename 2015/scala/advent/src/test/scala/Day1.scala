package advent

import org.scalatest.FunSpec
import Day1._

class Day1Spec extends FunSpec {
  describe("CountFloors correctly handles Input") {
    it("should return 0 for empty string"){
      val zero = CountFloors("")
      assert(zero == 0)
    }
    it("should return 0 for these strings"){
      val firstValue = CountFloors("(())")
      val secondValue = CountFloors("()()")
      assert(firstValue == 0)
      assert(secondValue == 0)
    }
    it("should return 3 for these strings"){
      val firstValue = CountFloors("(((")
      val secondValue = CountFloors("(()(()(")
      val thirdValue = CountFloors("))(((((")
      assert(firstValue == 3)
      assert(secondValue == 3)
      assert(thirdValue == 3)
    }
    it("should return -1 for these strings"){
      val firstValue = CountFloors("())")
      val secondValue = CountFloors("))(")
      assert(firstValue == -1)
      assert(secondValue == -1)
    }
    it("should return -3 for these strings"){
      val firstValue = CountFloors(")))")
      val secondValue = CountFloors(")())())")
      assert(firstValue == -3)
      assert(secondValue == -3)
    }
  }

  describe("EnterBasement correctly handles Input") {
    it("should return 1 for this string"){
      val value = EnterBasement(")")
      assert(value == 1)
     }
    it("should return 5 for this string"){
      val value = EnterBasement("()())")
      assert(value == 5)
    }
  }

}
