-- sql commands to create db

CREATE TABLE IF NOT EXISTS SensitivityRates (
    Id INTEGER PRIMARY KEY,
    Game TEXT,
    Rate REAL
);

INSERT INTO SensitivityRates (Game, Rate) VALUES ('cs2', 3.43);
INSERT INTO SensitivityRates (Game, Rate) VALUES ('overwatch', 1.62);

-- sqlite3 data/sensitivities.db < data/init.sql