
Select * From AncestryBaseTraits ab
Join Trait t on ab.TraitId = t.TraitId
Join Ancestry a on ab.AncestryId =a.AncestryId
Where ab.AncestryId = a.AncestryId AND a.AncestryName = 'Human';


  --ancestryModel = _context.AncestryBaseTraits
  --              .Include(a => a.TraitId)
  --              .Include(a =>a.AncestryId)
  --              .Where(a => a.AncestryId == a.Ancestry.AncestryId && a.Ancestry.AncestryName.Contains("Human"))
  --              .ToList();