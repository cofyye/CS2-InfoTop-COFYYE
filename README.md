# 🎯 [CS2] InfoTop (1.1)  

## 📌 Overview  
**InfoTop** is a plugin designed to display essential server information at the start of each round in **CS2**. This ensures players always have key details about the game in a clear and user-friendly format.  

### 🔹 Features  
- 📢 **Displays server info** at the start of every round.  
- 🌍 **Supports multiple languages** for a personalized experience.  
- 🖥️ **HUD Messages** for enhanced visibility.  
- 🎭 **Mini advertisements** configurable on-screen for announcements or promotions.  
- ⚙️ **Easy to install and configure**.  

---

## 🚀 See it in action  
Join my server to check out **InfoTop** live, along with other custom plugins I develop!  

🔹 **IP**: `198.186.131.31:27015`  

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

---

## 📥 Dependencies  

To run this plugin, ensure the following dependencies are installed:  

1️⃣ **Metamod:Source (2.x)**  
   🔗 [Download Here](https://www.sourcemm.net/downloads.php/?branch=master)  

2️⃣ **CounterStrikeSharp**  
   🔗 [Download Here](https://github.com/roflmuffin/CounterStrikeSharp/releases)  

---

## ⚙️ Installation & Configuration  

### 🔧 Installation Steps  
1. **Download** the latest release:  
   📥 [InfoTop v1.0](https://github.com/cofyye/CS2-InfoTop-COFYYE/releases/download/1.1/InfoTop-COFYYE-v1.1.zip)  
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
1. **`enable_welcome_msg`**  
   - **Values**: `true`, `false`  
   - **Description**: Enables or disables the welcome message.  

2. **`enable_addip_msg`**  
   - **Values**: `true`, `false`  
   - **Description**: Enables or disables the "Add IP to favorites" message.  

3. **`enable_infotop_text`**  
   - **Values**: `true`, `false`  
   - **Description**: Enables or disables the round info display.  

4. **`show_info_every_x_round`**  
   - **Values**: Integer (`1`, `2`, `3`, etc.)  
   - **Description**: Defines how often the info message should be displayed (every X rounds).  

### 🔹 HUD Messages & Ads  
5. **`enable_hud_ads`**  
   - **Values**: `true`, `false`  
   - **Description**: Enables or disables HUD advertisements.  

6. **`duration_per_hud_ad`**  
   - **Values**: Integer (e.g., `30`, `60`, `120`)  
   - **Description**: Duration in seconds for each HUD advertisement before changing.  

7. **`cooldown_per_hud_ad`**  
   - **Values**: Integer (e.g., `30`, `60`, `120`)  
   - **Description**: Cooldown period in seconds between each HUD advertisement.  

8. **`hud_rgb_color`**  
   - **Values**: `"R,G,B"` (e.g., `"255,165,0"`)  
   - **Description**: Sets the HUD text color using RGB values.  

9. **`hud_font_size`**  
   - **Values**: Integer (e.g., `20`, `30`, `35`)  
   - **Description**: Defines the font size for the HUD messages.  

10. **`hud_font_family`**  
   - **Values**: `"Font Name"` (e.g., `"Arial Bold"`)  
   - **Description**: Specifies the font family for HUD messages.  

11. **`hud_position_x`**  
   - **Values**: Float (e.g., `-2.4f`, `0.0f`, `2.0f`)  
   - **Description**: Defines the horizontal position of HUD messages.  

12. **`hud_position_y`**  
   - **Values**: Float (e.g., `3.8f`, `5.0f`, `-1.0f`)  
   - **Description**: Defines the vertical position of HUD messages.  

13. **`enable_hud_background`**  
   - **Values**: `true`, `false`  
   - **Description**: Enables or disables the HUD background for better readability.  

### 🔹 Welcome & Custom Messages  
14. **`welcome_messages`**  
   - **Values**: Multi-language message settings  
   - **Example**:  
     ```json
     {
       "welcome_message_1": {
         "sr": "[Info] ★彡 Dobrodosli na【 SERVER NAME 】彡★",
         "en": "[Info] ★彡 Welcome to【 SERVER NAME 】彡★"
       }
     }
     ```
   - **Description**: Sets the welcome messages in different languages.  

15. **`addip_messages`**  
   - **Values**: Multi-language message settings  
   - **Example**:  
     ```json
     {
       "addip_message_1": {
         "sr": "[Info] Dodajte IP u favorites ➤➤ 127.0.0.1:27015",
         "en": "[Info] Add IP to favorites ➤➤ 127.0.0.1:27015"
       }
     }
     ```
   - **Description**: Sets the "Add IP to favorites" messages in different languages.  

16. **`hud_messages`**  
   - **Values**: Multi-language HUD message settings  
   - **Example**:  
     ```json
     {
       "hud_message_1": {
         "sr": "Pridruzite se nasem Discord serveru, kucaj !discord",
         "en": "Join our Discord server, say !discord"
       }
     }
     ```
   - **Description**: Configures HUD messages in multiple languages.  

---

## 👥 Credits  

A huge **thank you** to [T3Marius](https://github.com/T3Marius) for his incredible help in implementing HUD messages via **WorldTextManager**! 🎉  
Without his expertise, this feature wouldn’t be as polished as it is! 🚀 

## 💰 Support & Donation  

If you enjoy this plugin and want to support its future development, consider donating:  

[☕ Donate on PayPal](https://paypal.me/cofyye)  

Your support is **greatly appreciated**! ❤️  

---

🔹 **Enjoy your game with InfoTop!** 🎮🔥
