# Additional clean files
cmake_minimum_required(VERSION 3.16)

if("${CONFIG}" STREQUAL "" OR "${CONFIG}" STREQUAL "Debug")
  file(REMOVE_RECURSE
  "CMakeFiles\\virtualWallet_autogen.dir\\AutogenUsed.txt"
  "CMakeFiles\\virtualWallet_autogen.dir\\ParseCache.txt"
  "virtualWallet_autogen"
  )
endif()
