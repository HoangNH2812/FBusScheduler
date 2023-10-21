import 'package:flutter/material.dart';

class Square extends StatelessWidget {
  final String imgPath;
  final Function()? onTap;
  const Square({
    super.key,
    required this.imgPath,
    this.onTap,
  });

  @override
  Widget build(BuildContext context) {
    // TODO: implement build
    return GestureDetector(
      onTap: onTap,
      child: Container(
        padding: const EdgeInsets.all(10),
        decoration: BoxDecoration(
          border: Border.all(color: Colors.grey),
          borderRadius: BorderRadius.circular(15),
          color: Colors.grey[100],
        ),
        child: Image.asset(
          imgPath,
          height: 35,
        ),
      ),
    );
  }
}
