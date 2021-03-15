import 'package:json_annotation/json_annotation.dart';

part 'coordinates.g.dart';

@JsonSerializable()
class Coordinates {
  int interStellar;
  int solar;
  int interPlanetar;
  int interLunar;
  int lunar;

  Coordinates(this.interStellar, this.solar, this.interPlanetar,
      this.interLunar, this.lunar);

  @override
  String toString() {
    return '($interStellar.$solar.$interPlanetar.$interLunar.$lunar)';
  }

  factory Coordinates.fromJson(Map<String, dynamic> json) =>
      _$CoordinatesFromJson(json);
  Map<String, dynamic> toJson() => _$CoordinatesToJson(this);
}
