SELECT
    D.Nome AS Departamento,
    P.Nome AS Pessoa,
    P.Salario AS Salario
FROM
    Pessoa AS P
JOIN (
    SELECT
        DeptId,
        MAX(Salario) AS SalarioMax
    FROM
        Pessoa
    GROUP BY
        DeptId
) AS T
ON
    P.DeptId = T.DeptId
    AND P.Salario = T.SalarioMax
JOIN
    Departamento AS D
ON
    P.DeptId = D.Id;