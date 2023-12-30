using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Skill
{
    public Skill left;
    public Skill center;
    public Skill right;
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
    public Skill SkillNode;
    public SkillBranch LeftSubBranch;
    public SkillBranch CenterSubBranch;
    public SkillBranch RightSubBranch;

    public SkillBranch(string branchName)
    {
        BranchName = branchName;
        SkillNode = null;
        LeftSubBranch = null;
        CenterSubBranch = null;
        RightSubBranch = null;
    }
}

public class SkillTree
{
    public SkillBranch Root { get; set; }

    public SkillTree()
    {
        Root = new SkillBranch("Root");

        // Add skills with levels 1 to 5 under each branch (Health, Speed, Gun Power)
        Root.LeftSubBranch = CreateSkillBranch("Health", 5);
        Root.CenterSubBranch = CreateSkillBranch("Speed", 5);
        Root.RightSubBranch = CreateSkillBranch("Gun Power", 5);
    }

    private SkillBranch CreateSkillBranch(string branchName, int levels)
    {
        SkillBranch branch = new SkillBranch(branchName);
        for (int i = 1; i <= levels; i++)
        {
            Skill skill = new Skill($"{branchName} Level {i}", $"Increase {branchName.ToLower()} - Level {i}", i, 0);
            skill.ExperienceRequired = CalculateTotalExperienceRequired(skill.Level);
            branch.SkillNode = InsertSkill(branch.SkillNode, skill);
        }
        return branch;
    }

    public Skill InsertSkill(Skill root, Skill skill)
    {
        if (root == null)
        {
            return skill;
        }

        if (skill.Level < root.Level)
        {
            root.left = InsertSkill(root.left, skill);
        }
        else if (skill.Level > root.Level)
        {
            root.right = InsertSkill(root.right, skill);
        }
        else
        {
            root.center = InsertSkill(root.center, skill);
        }

        return root;
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

            branch.SkillNode = InsertSkill(branch.SkillNode, skill);
        }
    }

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

        SkillBranch foundBranch = FindBranchRecursive(branch.LeftSubBranch, branchName);
        if (foundBranch == null)
        {
            foundBranch = FindBranchRecursive(branch.CenterSubBranch, branchName);
            if (foundBranch == null)
            {
                foundBranch = FindBranchRecursive(branch.RightSubBranch, branchName);
            }
        }

        return foundBranch;
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
