import json
import time
from tkinter import messagebox
import traceback

# Configuration paths
cfg_paths = [
    r"C:\Users\aap20\AppData\Local\ASK\Configs\SkinsWithItems.json",  # 0
    r"C:\Users\aap20\AppData\Local\ASK\Configs\SkinsPerks.json",  # 1
    r"C:\Users\aap20\AppData\Local\ASK\Configs\DlcOnly.json",  # 2
    r"C:\Users\aap20\AppData\Local\ASK\Configs\SkinsONLY.json"  # 3
]


def read_json(file_path):
    with open(file_path, 'r') as file:
        return json.load(file)


def write_json(file_path, data):
    with open(file_path, 'w') as file:
        json.dump(data, file, indent=4)


def generate_structure(object_id, quantity=1):
    return {
        "lastUpdatedAt": int(time.time()),
        "objectId": object_id,
        "quantity": quantity
    }


def update_file(cfg_path, new_data):
    if not new_data:
        return
    try:
        file_data = read_json(cfg_path)
        file_data["data"]["inventory"].extend(new_data)
        write_json(cfg_path, file_data)
    except Exception as e:
        print(f"Error updating {cfg_path}: {e}")


def process_items(upd_file, cur_outfit, cfg_path):
    mf, mf1, mf2, mf3 = [], [], [], []

    # Generate updates
    for x in upd_file["data"]["outfit"]["items"]:
        if x not in cur_outfit:
            mf.append(generate_structure(x))

    for x in upd_file["data"]["item"]["items"]:
        if x not in cur_outfit:
            mf1.append(generate_structure(x))

    for x in upd_file["data"]["character"]["items"]:
        if x not in cur_outfit:
            mf2.append(generate_structure(x))

    for x in upd_file["data"]["shrine"]["items"]:
        if x not in cur_outfit:
            mf3.append(generate_structure(x, quantity=3))

    # Update files
    if "SkinsWithItems.json" in cfg_path:
        update_file(cfg_path, mf + mf1)
        update_file(cfg_path, mf2)
        update_file(cfg_path, mf3)
    elif "DlcOnly.json" in cfg_path:
        update_file(cfg_path, mf2)
    elif "SkinsPerks.json" in cfg_path:
        update_file(cfg_path, mf + mf1 + mf3)
    elif "SkinsONLY.json" in cfg_path:
        update_file(cfg_path, mf + mf1)


# Main execution
try:
    upd_file = read_json(r"C:\Users\aap20\AppData\Local\ASK\Configs\AutoUpdate.json")
    for cfg_path in cfg_paths:
        cur_file = read_json(cfg_path)
        cur_outfit = [item["objectId"] for item in cur_file["data"]["inventory"] if item["quantity"]]
        process_items(upd_file, cur_outfit, cfg_path)
except FileNotFoundError as fnf_error:
    error_message = f"File not found: {fnf_error.filename}"
    print(error_message)
    if fnf_error.filename == "update.json": messagebox.showwarning(title="File Missing", message="The file 'update.json' could not be found. Please ensure it exists.")
except json.JSONDecodeError as json_error:
    print(f"JSON Decode Error in file: {json_error.msg}")
    messagebox.showerror(title="Invalid JSON", message=f"The file contains invalid JSON: {json_error.msg}")
except Exception as e:
    error_trace = traceback.format_exc()
    print("An unexpected error occurred:")
    print(error_trace)
    messagebox.showerror(title="Unexpected Error", message="An unexpected error occurred. Check the console for details.")