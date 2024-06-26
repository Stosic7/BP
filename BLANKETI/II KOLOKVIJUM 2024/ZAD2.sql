UPDATE ZAPOSLENI
SET PLATA = PLATA * 1.15
WHERE JMBG IN (
    SELECT DISTINCT ZJMBG
    FROM RADNO_MESTO
    WHERE DATUMDO IS NULL
    AND ZJMBG IN (
        SELECT ZJMBG
        FROM RADNO_MESTO
        JOIN KOMPANIJA ON RADNO_MESTO.IDK = KOMPANIJA.IDK
        WHERE KOMPANIJA.MESTO = 'Niš'
    )
    AND ZJMBG IN (
        SELECT ZJMBG
        FROM RADNO_MESTO
        WHERE DATUMDO IS NOT NULL
    )
);
