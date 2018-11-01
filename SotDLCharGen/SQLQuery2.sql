Select * From CharTrait ct
Right JOIN Trait t on ct.TraitId = t.TraitId
Where t.TraitId = 1;
