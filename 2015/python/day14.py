import math
import re


def deer_distance(speed, stamina, resting_time, total_time):
    # How many times has the deer covered the full distance in total_time
    times_full_distance = math.floor(total_time / (stamina + resting_time))
    total_distance = times_full_distance * (speed * stamina)

    # Sometimes there will still be a few seconds remaining,
    # how far can the deer go before either the time finishes or the stamina
    remaining_time = total_time % (stamina + resting_time)
    extra_distance = min(remaining_time, stamina) * speed

    return total_distance + extra_distance


def create_deer_info(deer):
    name = deer[0]
    speed = int(deer[1])
    stamina = int(deer[2])
    resting_time = int(deer[3])

    return name, speed, stamina, resting_time


def read_deer_info():
    deer_info = {}
    r = re.compile(r"(\w+)\D+(\d+)\D+(\d+)\D+(\d+)")
    total_time = 2503
    with open("input14.txt") as f:
        for line in f.readlines():
            match = r.findall(line)
            # findall returns a list with just one item
            name, speed, stamina, resting_time = create_deer_info(match[0])
            distance = deer_distance(speed, stamina, resting_time, total_time)
            deer_info[name] = distance

    return deer_info


def find_winning_deer():
    deer_info = read_deer_info()
    deer_name = max(deer_info, key=deer_info.get)
    return deer_info[deer_name]
