;;;; advent-2019.asd

(asdf:defsystem #:advent-2019
  :description "Advent 2019 solutions."
  :author "Tushar Tyagi"
  :license  "GNU GPLv3"
  :version "0.0.1"
  :serial t
  :components ((:file "package")
	       (:module "src" :serial t
			:components (
				     (:file "day-1")))))
