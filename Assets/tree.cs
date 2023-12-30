using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Skill
{
    public string Name;
    public string Description;
    public int Level;
    public int ExperienceRequired;

    public Skill(string name, string description, int level, int experienceRequired)
    {
        Name = name;
        Description = description;
        Level = level;
        ExperienceRequired = experienceRequired;
    }
}

[System.Serializable]
public class SkillBranch
{
    public string BranchName;
    public List<Skill> Skills;
    public List<SkillBranch> SubBranches;

    public SkillBranch(string branchName)
    {
        BranchName = branchName;
        Skills = new List<Skill>();
        SubBranches = new List<SkillBranch>();
    }
}

public class SkillTree
{
    public SkillBranch Root { get; set; }

    public SkillTree()
    {
        Root = new SkillBranch("Root");

        // Add Speed branch with levels 1 to 5
        SkillBranch speedBranch = new SkillBranch("Speed");
        for (int i = 1; i <= 5; i++)
        {
            Skill speedSkill = new Skill($"Speed Level {i}", $"Increase player speed - Level {i}", i, 0);
            speedSkill.ExperienceRequired = CalculateTotalExperienceRequired(speedSkill.Level);
            speedBranch.Skills.Add(speedSkill);
        }
        Root.SubBranches.Add(speedBranch);

        // Add Health branch with levels 1 to 5
        SkillBranch healthBranch = new SkillBranch("Health");
        for (int i = 1; i <= 5; i++)
        {
            Skill healthSkill = new Skill($"Health Level {i}", $"Increase player health - Level {i}", i, 0);
            healthSkill.ExperienceRequired = CalculateTotalExperienceRequired(healthSkill.Level);
            healthBranch.Skills.Add(healthSkill);
        }
        Root.SubBranches.Add(healthBranch);

        // Add Power branch with levels 1 to 5
        SkillBranch powerBranch = new SkillBranch("Power");
        for (int i = 1; i <= 5; i++)
        {
            Skill powerSkill = new Skill($"Power Level {i}", $"Increase shooting power - Level {i}", i, 0);
            powerSkill.ExperienceRequired = CalculateTotalExperienceRequired(powerSkill.Level);
            powerBranch.Skills.Add(powerSkill);
        }
        Root.SubBranches.Add(powerBranch);
    }

    public void AddSkill(string branchName, Skill skill)
    {
        // Find the branch with the given name and add the skill
        SkillBranch branch = FindBranch(branchName);
        if (branch != null)
        {
            // Set the XP requirements for each level
            for (int i = 1; i <= skill.Level; i++)
            {
                skill.ExperienceRequired += CalculateExperienceRequired(i);
            }

            branch.Skills.Add(skill);
        }
    }

    // Rest of the methods remain unchanged...

    private SkillBranch FindBranch(string branchName)
    {
        // Find a branch with the given name in the entire tree
        return FindBranchRecursive(Root, branchName);
    }

    private SkillBranch FindBranchRecursive(SkillBranch branch, string branchName)
    {
        // Recursive helper method to find a branch with the given name
        if (branch == null)
        {
            return null;
        }

        if (branch.BranchName == branchName)
        {
            return branch;
        }

        foreach (SkillBranch subBranch in branch.SubBranches)
        {
            SkillBranch foundBranch = FindBranchRecursive(subBranch, branchName);
            if (foundBranch != null)
            {
                return foundBranch;
            }
        }

        return null;
    }

    private int CalculateExperienceRequired(int level)
    {
        // You can implement a formula to determine the XP required for each level
        // For simplicity, let's say it's a constant amount for each level
        return level * 100; // Adjust this formula based on your game's progression curve
    }

    private int CalculateTotalExperienceRequired(int level)
    {
        // Calculate the total XP required to reach the specified level
        int totalXP = 0;
        for (int i = 1; i <= level; i++)
        {
            totalXP += CalculateExperienceRequired(i);
        }
        return totalXP;
    }
}
