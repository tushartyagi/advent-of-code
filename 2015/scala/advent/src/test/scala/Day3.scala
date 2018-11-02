package advent

import org.scalatest._
import Day3._

class Day3Spec extends FunSpec {
  describe("move() works correctly") {
    val pos: Move = (5, 5)
    it("should increment x by 1 for >"){
      val right = move('>', pos)
      assert(right.==((6, 5)))
    }
    it("should decrement x by 1 for <"){
      val right = move('<', pos)
      assert(right.==((4, 5)))
    }
    it("should increment y by 1 for v"){
      val right = move('v', pos)
      assert(right.==((5, 6)))
    }
    it("should decrement y by 1 for ^"){
      val right = move('^', pos)
      assert(right.==((5, 4)))
    }  
  }

  describe("moves() gives the list of houses visited from the start"){
    val init: Move = (0,0)
    it("should throw exception for empty list"){
      val positions = moves("<><>".toList)
      assert(positions == List((-1, 0), (1, 0), (-1, 0), (1, 0)))
    }
  }

  describe("iterativeMovement uniquely identifies the houses visited from the start"){
    it("should return 2 for visiting two houses multiple times") {
      val moves = "<><>".toList
      val houses = iterativeMovement(moves)
      assert(houses == 2)
    }
    it("should return 2 for >"){
      val moves = ">".toList
      assert(iterativeMovement(moves) == 2)
    }
    it("should return 4 for ^>v<"){
      val moves = "^>v<".toList
      assert(iterativeMovement(moves) == 4)
    }
    it("should return 2 for ^>v<"){
      val moves = "^v^v^v^v^v".toList
      assert(iterativeMovement(moves) == 2)
    }
  }
  describe("tailRecursiveMovement uniquely identifies the houses visited from the start"){
    it("should return 2 for visiting two houses multiple times") {
      val moves = "<><>".toList
      val houses = tailRecursiveMovement(moves)
      assert(houses == 2)
    }
    it("should return 2 for >"){
      val moves = ">".toList
      assert(tailRecursiveMovement(moves) == 2)
    }
    it("should return 4 for ^>v<"){
      val moves = "^>v<".toList
      assert(tailRecursiveMovement(moves) == 4)
    }
    it("should return 2 for ^>v<"){
      val moves = "^v^v^v^v^v".toList
      assert(tailRecursiveMovement(moves) == 2)
    }
  }
}
