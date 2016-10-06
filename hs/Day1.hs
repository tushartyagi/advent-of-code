countParens [] = 0
countParens (x:xs) 
  | x == '(' = (countParens xs) + 1
  | x == ')' = (countParens xs) - 1

countFloors [] = 0
countFloors ss = helper 0 0 ss
  where helper (-1) pos _ = pos
        helper floor pos ('(':ss') = helper (floor + 1) (pos + 1) ss'
        helper floor pos (')':ss') = helper (floor - 1) (pos + 1) ss'
