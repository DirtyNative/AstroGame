import 'package:json_annotation/json_annotation.dart';

part 'vector_3.g.dart';

@JsonSerializable()
class Vector3 {
  double x;
  double y;
  double z;

  Vector3();

  @override
  String toString() {
    return '($x:$y:$z)';
  }

  factory Vector3.fromJson(Map<String, dynamic> json) => _$Vector3FromJson(json);
  Map<String, dynamic> toJson() => _$Vector3ToJson(this);
}
