# 🎯 [CS2] InfoTop

## 📊 Plugin Statistics

<p align="center">
  <img src="https://img.shields.io/github/downloads/cofyye/CS2-InfoTop-COFYYE/total" alt="Total Downloads">
  <img src="https://img.shields.io/github/stars/cofyye/CS2-InfoTop-COFYYE" alt="GitHub Stars">
  <img src="https://img.shields.io/github/last-commit/cofyye/CS2-InfoTop-COFYYE" alt="Last Update">
  <img src="https://img.shields.io/github/issues/cofyye/CS2-InfoTop-COFYYE" alt="Open Issues">
</p>

## 📌 Overview

**InfoTop** is a plugin designed to display essential server information at the start of each round in **CS2**. This ensures players always have key details about the game in a clear and user-friendly format.

### 🔹 Features

- 📢 **Displays server info** at the start of every round.
- 🌍 **Supports multiple languages** for a personalized experience.
- 🖥️ **HUD Messages** for enhanced visibility.
- 🎭 **Mini advertisements** configurable on-screen for announcements or promotions.
- ⚙️ **Easy to install and configure**.

---

## 🚀 Join Our Community

Join our **Discord server** to get support, share feedback, and stay updated with the latest plugin releases!

🔹 **Discord**: [https://discord.gg/xPTZ2uFgCt](https://discord.gg/xPTZ2uFgCt)

---

## 🖥️ How It Looks

Here are some screenshots showcasing **InfoTop** in action:

### 📌 Standard Round Info

![InfoTop EN](https://github.com/cofyye/CS2-InfoTop-COFYYE/blob/resources/infotop_en.png?raw=true)  
![InfoTop SR](https://github.com/cofyye/CS2-InfoTop-COFYYE/blob/resources/infotop_sr.png?raw=true)

### 📌 HUD Messages

The plugin also features **HUD messages** that appear on-screen for better visibility. These messages support multiple languages and provide important information in real-time.

![InfoTop HUD 1](https://github.com/cofyye/CS2-InfoTop-COFYYE/blob/resources/infotop_hud_en_1.png?raw=true)  
![InfoTop HUD 2](https://github.com/cofyye/CS2-InfoTop-COFYYE/blob/resources/infotop_hud_en_2.png?raw=true)

### 📌 HUD Messages with Player Name Support

![InfoTop HUD Player Name EN](https://github.com/cofyye/CS2-InfoTop-COFYYE/blob/resources/infotop_hud_playername_en.jpg?raw=true)  
![InfoTop HUD Player Name SR](https://github.com/cofyye/CS2-InfoTop-COFYYE/blob/resources/infotop_hud_playername_sr.jpg?raw=true)

### 📌 Multi-line Message Support with {NEXTLINE}

![InfoTop NextLine](https://github.com/cofyye/CS2-InfoTop-COFYYE/blob/resources/infotop_nextline.jpg?raw=true)

---

## 📥 Dependencies

To run this plugin, ensure the following dependencies are installed:

1️⃣ **Metamod:Source (2.x)**  
 🔗 [Download Here](https://www.sourcemm.net/downloads.php/?branch=master)

2️⃣ **CounterStrikeSharp**  
 🔗 [Download Here](https://github.com/roflmuffin/CounterStrikeSharp/releases)

3️⃣ **CS2-GameHUD**  
 🔗 [Download Here](https://github.com/darkerz7/CS2-GameHUD/releases)

---

## ⚙️ Installation & Configuration

### 🔧 Installation Steps

1. **Download** the latest release:  
   📥 [InfoTop v1.3](https://github.com/cofyye/CS2-InfoTop-COFYYE/releases/download/1.3/InfoTop-COFYYE-v1.3.zip)
2. **Extract & Upload** the contents into:
   > `game/csgo/addons/counterstrikesharp/plugins`
3. **Restart the server** or **change the map** to activate the plugin.
4. The plugin will now **automatically start working**! 🚀

### 🌍 Language & Config Support

All configurations, including language settings, can be adjusted in the following file:

> `game/csgo/addons/counterstrikesharp/configs/plugins/InfoTop-COFYYE/InfoTop-COFYYE.json`

---

## ⚙️ Configuration Options

### 🔹 General Settings

1. **`prefix`**

   - **Values**: String (e.g., `"{lightpurple}[InfoTop] {orange}»» "`)
   - **Description**: Sets the prefix for chat messages.

2. **`enable_welcome_msg`**

   - **Values**: `true`, `false`
   - **Description**: Enables or disables the welcome message.

3. **`enable_addip_msg`**

   - **Values**: `true`, `false`
   - **Description**: Enables or disables the "Add IP to favorites" message.

4. **`enable_infotop_text`**

   - **Values**: `true`, `false`
   - **Description**: Enables or disables the round info display.

5. **`show_info_every_x_round`**
   - **Values**: Integer (`1`, `2`, `3`, etc.)
   - **Description**: Defines how often the info message should be displayed (every X rounds).

### 🔹 HUD Messages & Ads

6. **`enable_hud_ads`**

   - **Values**: `true`, `false`
   - **Description**: Enables or disables HUD advertisements.

7. **`duration_per_hud_ad`**

   - **Values**: Integer (e.g., `30`, `60`, `120`)
   - **Description**: Duration in seconds for each HUD advertisement before changing.

8. **`cooldown_per_hud_ad`**

   - **Values**: Integer (e.g., `30`, `60`, `120`)
   - **Description**: Cooldown period in seconds between each HUD advertisement.

9. **`hud_rgb_color`**

   - **Values**: `"R,G,B"` (e.g., `"255,165,0"`)
   - **Description**: Sets the HUD text color using RGB values.

10. **`hud_font_size`**

- **Values**: Integer (e.g., `20`, `30`, `35`)
- **Description**: Defines the font size for the HUD messages.

11. **`hud_font_family`**

- **Values**: `"Font Name"` (e.g., `"Arial Bold"`)
- **Description**: Specifies the font family for HUD messages.

12. **`hud_position_x`**

- **Values**: Float (e.g., `-2.4f`, `0.0f`, `2.0f`)
- **Description**: Defines the horizontal position of HUD messages.

13. **`hud_position_y`**

- **Values**: Float (e.g., `3.8f`, `5.0f`, `-1.0f`)
- **Description**: Defines the vertical position of HUD messages.

14. **`hud_bg_border_height`**

- **Values**: Float (e.g., `0.5f`)
- **Description**: Defines the HUD background border height.

15. **`hud_bg_border_width`**

- **Values**: Float (e.g., `0.5f`)
- **Description**: Defines the HUD background border width.

16. **`hud_font_units`**

- **Values**: Float (e.g., `0.25f`)
- **Description**: Defines the font unit scale for HUD messages.

### 🔹 Welcome & Custom Messages

17. **`welcome_messages`**

- **Values**: Multi-language message settings
- **Example**:
  ```json
  "welcome_messages": {
    "welcome_message_1": {
      "sr": "{orange}★彡 {yellow}Dobrodosli na{orange}【 {lime}{HOSTNAME}{orange} 】彡★",
      "en": "{orange}★彡 {yellow}Welcome to{orange}【 {lime}{HOSTNAME}{orange} 】彡★"
    }
  }
  ```
- **Description**: Sets the welcome messages in different languages. Supports `{NEXTLINE}` for multi-line messages.

18. **`addip_messages`**

- **Values**: Multi-language message settings
- **Example**:
  ```json
  "addip_messages": {
    "addip_message_1": {
      "sr": "{yellow}Dodajte IP u favorites {orange}➤➤ {lime}{IP}",
      "en": "{yellow}Add IP to favorites {orange}➤➤ {lime}{IP}"
    }
  }
  ```
- **Description**: Sets the "Add IP to favorites" messages in different languages. Supports `{NEXTLINE}` for multi-line messages.

19. **`infotop_text_messages`**

- **Values**: Multi-language message settings
- **Example**:
  ```json
  "infotop_text_messages": {
    "infotop_text_message_1": {
      "sr": "{yellow}Runda: {lime}{CURRENT_ROUNDS}{yellow}/{lime}{MAX_ROUNDS} {NEXTLINE} {yellow}Mapa: {lime}{CURRENT_MAP} {NEXTLINE} {yellow}Igraci: {lime}{CURRENT_PLAYERS}{yellow}/{lime}{MAX_PLAYERS}",
      "en": "{yellow}Round: {lime}{CURRENT_ROUNDS}{yellow}/{lime}{MAX_ROUNDS} {NEXTLINE} {yellow}Map: {lime}{CURRENT_MAP} {NEXTLINE} {yellow}Players: {lime}{CURRENT_PLAYERS}{yellow}/{lime}{MAX_PLAYERS}"
    }
  }
  ```
- **Description**: Configures the info text messages. Supports `{NEXTLINE}` for multi-line messages.

20. **`hud_messages`**

- **Values**: Multi-language HUD message settings
- **Example**:
  ```json
  "hud_messages": {
    "hud_message_1": {
      "sr": "Dodajte IP u favorites ➤➤ {IP}",
      "en": "Add IP to favorites ➤➤ {IP}"
    }
  }
  ```
- **Description**: Configures HUD messages in multiple languages. Does **NOT** support `{NEXTLINE}`.

---

## 🎉 Credits for Version 1.1

A huge **thank you** to [T3Marius](https://github.com/T3Marius) for his incredible help in improving HUD messages in **version 1.1**! 🎉  
His expertise with **WorldTextManager** made this update smoother and more polished than ever! 🚀

## 💰 Support & Donation

If you enjoy this plugin and want to support its future development, consider donating:

[☕ Donate on PayPal](https://paypal.me/cofyye)

Your support is **greatly appreciated**! ❤️

---

🔹 **Enjoy your game with InfoTop!** 🎮🔥
