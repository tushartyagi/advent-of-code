;;;; advent-2019.asd

(asdf:defsystem #:advent-2019
    :description "Solution to advent of code 2019"
  :author "Tushar Tyagi"
  :license  "GNU GPLv3"
  :version "0.0.1"

  :serial t
  :components ((:module "src" :serial t
                        :components ((:file "package")
                                     (:file "day-1")))))
