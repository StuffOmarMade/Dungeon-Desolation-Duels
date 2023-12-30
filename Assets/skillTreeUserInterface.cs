using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class skillTreeUserInterface : MonoBehaviour
{
    public Text healthText;
    public Text speedText;
    public Text gunPowerText;
    public Text xpText;

    public SkillTree skillTree;
    private int xp;

    void Start()
    {
        // Assuming you have a SkillTree instance somewhere in your game
        skillTree = new SkillTree();

        // Initialize UI
        UpdateUI();
    }

    void Update()
    {
        // Check for player input or any other conditions to upgrade skills
        // For simplicity, let's assume the player gets 1 XP for every kill
        if (Input.GetKeyDown(KeyCode.U))
        {
            GainXP(1);
        }
    }

    void GainXP(int amount)
    {
        xp += amount;
        UpdateUI();
    }

    void UpdateUI()
    {
        xpText.text = "XP: " + xp.ToString();

        // Display skill levels and descriptions
        healthText.text = GetSkillText("Health", skillTree.Root.LeftSubBranch.SkillNode);
        speedText.text = GetSkillText("Speed", skillTree.Root.CenterSubBranch.SkillNode);
        gunPowerText.text = GetSkillText("Gun Power", skillTree.Root.RightSubBranch.SkillNode);
    }

    string GetSkillText(string skillName, Skill skill)
    {
        return $"{skillName}: Level {skill?.Level ?? 0}\n{skill?.Description ?? "Locked"}";
    }

    // Methods to handle button clicks
    public void UpgradeHealth()
    {
        UpgradeSkill(skillTree.Root.LeftSubBranch);
    }

    public void UpgradeSpeed()
    {
        UpgradeSkill(skillTree.Root.CenterSubBranch);
    }

    public void UpgradeGunPower()
    {
        UpgradeSkill(skillTree.Root.RightSubBranch);
    }

    void UpgradeSkill(SkillBranch branch)
    {
        if (branch != null && branch.SkillNode != null && xp >= branch.SkillNode.ExperienceRequired)
        {
            // Deduct XP and upgrade the skill
            xp -= branch.SkillNode.ExperienceRequired;
            branch.SkillNode = skillTree.InsertSkill(branch.SkillNode, new Skill(
                branch.BranchName + $" Level {branch.SkillNode.Level + 1}",
                $"Increase {branch.BranchName.ToLower()} - Level {branch.SkillNode.Level + 1}",
                branch.SkillNode.Level + 1,
                CalculateTotalExperienceRequired(branch.SkillNode.Level + 1)
            ));

            UpdateUI();
        }
    }

    int CalculateTotalExperienceRequired(int level)
    {
        // Your XP calculation logic goes here (e.g., level * 100)
        return level * 100;
    }
}
