
def check_routing_number(rn):
    if rn is None or not isinstance(rn, str) or len(rn) < 9:
        return False
    try:
        return (3*(int(rn[0]) + int(rn[3]) + int(rn[6])) + 7*(int(rn[1]) + int(rn[4]) + int(rn[7])) + (int(rn[2]) + int(rn[5])+ int(rn[8]))) % 10 == 0
    except:
        return False

print(check_routing_number("111000025"))
print(check_routing_number(None))
print(check_routing_number(""))
print(check_routing_number("abc"))
print(check_routing_number(False))