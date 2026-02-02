use collage;

WITH AvgM2ByDept AS (
	SELECT  Department, AVG(M2) AS AvgM2
	FROM CollageMaster
	GROUP BY Department
)
SELECT * 
FROM AvgM2ByDept;


----------------------------
-- Find the 3rd max m1 marks

SELECT DISTINCT M1 
FROM CollageMaster
ORDER BY M1 DESC
OFFSET 2 ROWS
FETCH NEXT 1 ROW ONLY;


 select M2 from CollageMaster order by M2 desc limit 1 offset 1;

 ---------------------------------------------------------------------
 --WHICH DEPT SCORES THE HIGHEST M1 

WITH DeptHighestM1 AS(
	SELECT Department, SUM(M1) AS SUMM1
	FROM CollageMaster
	GROUP BY Department
)
SELECT Department
FROM DeptHighestM1 
ORDER BY  SUMM1 DESC
OFFSET 2 ROWS
FETCH NEXT 1 ROW ONLY;
