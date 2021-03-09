import 'package:astrogame_app/converters/guid_converter.dart';
import 'package:astrogame_app/models/stellar/base_types/stellar_system.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:json_annotation/json_annotation.dart';

part 'multi_object_system.g.dart';

@GuidConverter()
@JsonSerializable()
class MultiObjectSystem extends StellarSystem {
  @JsonKey()
  Guid parentId;

  @JsonKey()
  StellarSystem parent;

  @JsonKey()
  int order;

  @JsonKey()
  List<StellarSystem> satellites;

  @JsonKey()
  List<StellarSystem> centerSystems;

  MultiObjectSystem(
    Guid id,
    String name,
    this.parentId,
    this.parent,
    this.order,
    this.satellites,
    this.centerSystems,
  ) : super(id, name);

  factory MultiObjectSystem.fromJson(Map<String, dynamic> json) =>
      _$MultiObjectSystemFromJson(json);
  Map<String, dynamic> toJson() => _$MultiObjectSystemToJson(this);
}
